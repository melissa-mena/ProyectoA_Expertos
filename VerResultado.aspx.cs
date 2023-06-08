using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Login_InfoToolsSV
{ 
    public partial class VerResultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Formulario formulario = new Formulario();
                List<string> respuestas = formulario.ObtenerRespuestas();
                string tipoInteligencia = CalcularTipoInteligencia(respuestas);
                // Establecer el texto del control Label
                lblTipoInteligencia.Text = "Tu tipo de inteligencia es: "+ tipoInteligencia;
            }

        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_InfoToolsSV.aspx");
        }
        protected void BtnIngresar_Click (object sender,EventArgs e)
        {
            
        }

       
        private static string CalcularTipoInteligencia(List<string> respuestas) // Algoritmo Euclides
        {
            Dictionary<string, double> distancias = new Dictionary<string, double>()
            {
                { "espacial", 0 },
                { "musical", 0 },
                { "lingüístico-verbal", 0 },
                { "lógico-matemático", 0 },
                { "corporal cinestésico", 0 },
                { "intrapersonal", 0 },
                { "interpersonal", 0 },
                { "naturalista", 0 },
                { "existencial", 0 },
                { "creativo", 0 },
                { "emocional", 0 },
                { "colaborativo", 0 }
            };

            int preguntaIndex = 0;

            // Calcula las distancias entre las respuestas y los tipos de inteligencia
            foreach (string respuesta in respuestas)
            {
                string tipoInteligencia = GetTipoInteligenciaByPreguntaIndex(preguntaIndex);

                if (distancias.ContainsKey(tipoInteligencia))
                {
                    int puntajeRespuesta = ObtenerPuntajeRespuesta(respuesta);
                    distancias[tipoInteligencia] += Math.Pow(puntajeRespuesta, 2);
                }

                preguntaIndex++;
            }

            // Crear una copia de las claves del diccionario
            List<string> tiposInteligencia = new List<string>(distancias.Keys);

            // Normalizar las distancias
            foreach (string tipoInteligencia in tiposInteligencia)
            {
                distancias[tipoInteligencia] = Math.Sqrt(distancias[tipoInteligencia]);
            }

            // Encuentra el tipo de inteligencia con la distancia más baja (más cercano)
            string tipoInteligenciaPredominante = string.Empty;
            double minDistancia = double.MaxValue;

            foreach (KeyValuePair<string, double> kvp in distancias)
            {
                if (kvp.Value < minDistancia)
                {
                    minDistancia = kvp.Value; // enviar a bd
                    tipoInteligenciaPredominante = kvp.Key;
                }
            }

            return tipoInteligenciaPredominante; //enviar a bd
        }


        private static string GetTipoInteligenciaByPreguntaIndex(int preguntaIndex)
        {
            // Mapear el índice de la pregunta al tipo de inteligencia correspondiente
            string[] tiposInteligencia = {
                "espacial", "musical", "lingüístico-verbal", "lógico-matemático", "corporal cinestésico",
               "intrapersonal", "interpersonal", "naturalista", "existencial", "creativo", "emocional", "colaborativo"
            };

            int tipoIndex = preguntaIndex / 3; // Dividir por 3 porque hay 3 preguntas por tipo de inteligencia
            return tiposInteligencia[tipoIndex];
        }

        private static int ObtenerPuntajeRespuesta(string respuesta)
        {
            // Asignar un puntaje a cada respuesta
            if (respuesta == "Siempre")
            {
                return 0;
            }
            else if (respuesta == "A veces")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }

}
