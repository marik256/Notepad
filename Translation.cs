using Amazon;
using Amazon.Runtime;
using Amazon.Translate;
using Amazon.Translate.Model;

namespace Notepad
{
    internal sealed class Translation
    {
        private static readonly string accessKey = "";
        private static readonly string secretKey = "";
        
        internal static string GetTranslatedText(string sourceText, string sourceLanguageCode, string targetLanguageCode)
        {
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            var translateRequest = new TranslateTextRequest
            {
                Text = sourceText,
                SourceLanguageCode = sourceLanguageCode,
                TargetLanguageCode = targetLanguageCode
            };
            string translatedText;

            using (var translateClient = new AmazonTranslateClient(credentials, RegionEndpoint.EUWest3))
            {
                translatedText = translateClient.TranslateText(translateRequest).TranslatedText;
            }

            return translatedText;
        }
    }
}
