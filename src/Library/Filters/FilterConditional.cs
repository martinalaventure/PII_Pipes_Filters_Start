using System;
using System.Diagnostics.Contracts;
using CompAndDel;
using CompAndDel.Filters;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter
    {
        public bool hasFace { get; set; }

        public IPicture Filter(IPicture image)
        {
            hasFace = false;

            CognitiveFace cognitiveFace = new CognitiveFace();
            // Realiza la detección de caras y devuelve un valor booleano.
            cognitiveFace.Recognize(@"luke.jpg");

            // asigno el valor del reconocimiento al atributo hasFace.
            hasFace = cognitiveFace.FaceFound;

            return image;
        }
    }
}
