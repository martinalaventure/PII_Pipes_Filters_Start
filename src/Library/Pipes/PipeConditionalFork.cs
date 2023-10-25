using System;
using CompAndDel;
using CompAndDel.Filters;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipe
    {
        private FilterConditional filterConditional;
        private IPipe hasFacePipe;
        private IPipe noFacePipe;

        public PipeConditionalFork(FilterConditional filterConditional, IPipe hasfacepipe, IPipe nofacepipe)
        {
            this.filterConditional = filterConditional;
            this.hasFacePipe = hasfacepipe;
            this.noFacePipe = nofacepipe;
        }
        public IPicture Send(IPicture picture)
        {
            // Aplicamos el filtro condicional para determinar si hay una cara en la imagen.
            filterConditional.Filter(picture);

            // Verificamos si se detectó una cara.
            bool hasFace = filterConditional.hasFace;

            // En función del resultado, enviamos la imagen a la tubería correspondiente.
            if (hasFace)
            {
                return hasFacePipe.Send(picture);
            }
            else
            {
                return noFacePipe.Send(picture);
            }
        }
    }
}
