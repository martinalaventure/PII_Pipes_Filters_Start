using System;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        public IPicture Filter(IPicture input)
        {
            // Publicar la imagen en Twitter
            var twitter = new TwitterImage();

            // Ruta a la imagen a publicar
            string imagePath = "finalResult.jpg";

            // Texto del tweet
            string tweetText = "¡Mira mi imagen transformada!";

            // Publica la imagen en Twitter
            string publishResult = twitter.PublishToTwitter(tweetText, imagePath);

            Console.WriteLine("Resultado de la publicación en Twitter: " + publishResult);

            // Devuelve la imagen 
            return input;
        }
    }
}