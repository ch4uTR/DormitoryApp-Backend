using AutoMapper;
using Entity.DTOs.Notification;
using Entity.Models;
using FirebaseAdmin.Messaging;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class NotificationService : INotificationService
    {   
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public NotificationService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<NotificationTokenDto> SaveUserToken(string userId, NotificationTokenDto notificationTokenDto)
        {
            var existingToken = await _repositoryManager.NotificationToken.GetByFcmToken(notificationTokenDto.FcmToken);
            
            if (existingToken != null)
            {
                existingToken.UserId = userId;
                existingToken.LastUpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var newToken = _mapper.Map<NotificationToken>(notificationTokenDto);
                newToken.UserId = userId;
                _repositoryManager.NotificationToken.Create(newToken);
            }

      
            await _repositoryManager.SaveAsync();
            return notificationTokenDto;
        }

        public async Task SendNotificationAsync(string token, NotificationContentDto notificationContentDto)
        {
            try
            {
                var message = new Message()
                {
                    Token = token,
                    Notification = new Notification
                    {
                        Title = notificationContentDto.Title,
                        Body = notificationContentDto.Body,
                    }
                };
                string response = await FirebaseMessaging.DefaultInstance.SendAsync(message); 


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Bildirim gönderilemedi. Hata mesajı: {ex.Message}");
            }
        }

        public async Task SendNotificationToUserAsync(string userId, NotificationContentDto notificationContentDto)
        {
            var userTokens = await _repositoryManager.NotificationToken.GetAllByUserId(userId, false);

            if (userTokens != null && userTokens.Any()) {

                var tasks = userTokens.Select(t => SendNotificationAsync(t.FcmToken, notificationContentDto));
                await Task.WhenAll(tasks);
                await SendToPushOver(notificationContentDto.Title, notificationContentDto.Body ?? "Tebrikler1!!");
                return;
            }
                   
            throw new Exception($"Id nosu: {userId} olan kullanıcının kayıtlı cihazı bulunamadı!");
            

                
        }


        private async Task SendToPushOver(string title, string body)
        {
            using (var client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                {
                    { "token", "a87aokpbk74igogt6g7w3vskxzsoha"},
                    { "user" , "u5tfe2vux5wrdwu3kh357q41g9d2me"},
                    { "title" ,title },
                    {"message", body },
                    {"sound", "magic" }

                };

                await client.PostAsync("https://api.pushover.net/1/messages.json", new FormUrlEncodedContent(parameters));
                ;
            }
        }
    }
}
