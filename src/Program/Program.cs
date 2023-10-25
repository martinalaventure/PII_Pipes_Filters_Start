using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;
using Ucu.Poo.Cognitive;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            // Crear filtros
            IFilter filterNegative = new FilterNegative();
            IFilter filterGreyscale = new FilterGreyscale();
            FilterConditional filterConditional = new FilterConditional();
            IFilter filterTwitter = new FilterTwitter();

            // Crear el PipeConditionalFork para bifurcar según la condición de FilterConditional
            IPipe hasFacePipe = new PipeSerial(filterTwitter, new PipeNull());
            IPipe noFacePipe = new PipeSerial(filterNegative, new PipeNull());

            IPipe conditionalForkPipe = new PipeConditionalFork(filterConditional,hasFacePipe, noFacePipe);

            IPipe finalPipe = new PipeSerial(filterGreyscale, conditionalForkPipe);

             // Crear un PictureProvider para la persistencia de imágenes
            PictureProvider pictureProvider = new PictureProvider();

            // guardar la imagen inicial
            IPicture initialpicture = picture;
            pictureProvider.SavePicture(initialpicture, "initialpicture.jpg");
            
            // Guardar la imagen intermedia solo si se aplicó el filtro negativo (no hay cara) ya que si hay cara la imagen no vuelve a ser editada.
            IPicture intermediaResult = noFacePipe.Send(initialpicture);
            pictureProvider.SavePicture(intermediaResult, "intermediateresult.jpg");

            // Enviar la imagen a través de la tubería final
            IPicture finalResult = finalPipe.Send(intermediaResult);
            pictureProvider.SavePicture(finalResult, "finalResult.jpg");

        }
    }
}
