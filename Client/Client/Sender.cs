using System.Net.Http.Headers;

namespace Client
{
    public class Sender
    {
        string Url = ""; //TODO: добавить адрес сервера

        public string UploadYamlFile(string FilePath) 
        {
            var RequestParametrs = new List<KeyValuePair<string, string>>() {new KeyValuePair<string, string>("upload_file","upload_file") };
            var Client = new HttpClient();
            var Content = new MultipartFormDataContent();
            Content.Add(new FormUrlEncodedContent(RequestParametrs));

            using (var FileStream = File.OpenRead(FilePath))
            {
                var FileToUpload = new StreamContent(FileStream);
                FileToUpload.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "Upload", FileName = Path.GetFileName(FilePath)
                };

                Content.Add(FileToUpload);

            var Response = Client.PostAsync(Url, Content);

                return Response.Result.ToString();
            }
        }
    }
}
