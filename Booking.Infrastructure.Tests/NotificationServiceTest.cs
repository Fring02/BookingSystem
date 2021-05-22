using Domain.Helpers;
using Infrastructure.Services;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Infrastructure.Tests
{
    public class NotificationServiceTest
    {


        [Theory]
        [InlineData("hasenovsultantest@gmail.com", "qwerty456123")]
        public async Task Check_SendEmailAsync_To_Recipient(string recipient, string password)
        {
            //Arrange
            var mockOptions = new Mock<IOptions<EmailConfiguration>>();
            mockOptions.Setup(o => o.Value).Returns(new EmailConfiguration
            {
                FromEmail = "hasenovsultanbek@gmail.com",
                SmtpServer = "smtp.gmail.com",
                Port = 587,
                Username = "hasenovsultanbek@gmail.com",
                Password = "Rubin1!!",
                Url = "https://localhost:44362/confirm"
            });
            var service = new NotificationService(mockOptions.Object);
            //Act
            Task isSent = service.SendEmailAsync(recipient, password);
            await isSent;
            //Assert
            Assert.True(isSent.IsCompletedSuccessfully);
        }
    }
}
