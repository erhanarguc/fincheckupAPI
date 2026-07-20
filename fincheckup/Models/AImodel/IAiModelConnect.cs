using ChatGptNet;
using ChatGptNet.Extensions;
using ChatGptNet.Models;
using System;
using System.Threading.Tasks;

 
public class IAiModelConnect(IChatGptClient chatGptClient)
{
     
    public async Task<string> FirstSetupAsync(string systemMessage) {

            var conversationId = Guid.NewGuid();
            string retMessage = "";

        
            if (!string.IsNullOrWhiteSpace(systemMessage))
            {
                await chatGptClient.SetupAsync(conversationId, "You are an helpful assistant");
            }

        var response1 = await chatGptClient.AskAsync(conversationId, "bilanço ve gelir tablosuna göre  finansal durumunun özetini ve değerlendirmesini   Finansal tablo verilerini rakam olarak yazmadan ve giriş cümlesi ve giriş başlığı kullanmadan 39 satırda    ifade edebilir misin", new ChatGptParameters
        {
            MaxTokens = 4096,
            Temperature = 0.7
        });

        var response = await chatGptClient.AskAsync(conversationId, systemMessage, new ChatGptParameters
            {
                MaxTokens = 4096,
                Temperature = 0.7
            });

            retMessage += response.GetContent();
            return  retMessage;
        
        
        }
    }
 
