using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Servicios;
using Entidades;

namespace Login_InfoToolsSV
{ 
    public partial class VerResultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegistroServicios registroServicios = new RegistroServicios();
                Formulario formulario = new Formulario();
                Login_InfoToolsSV log = new Login_InfoToolsSV();
                Usuarios user = log.ObtenerUsuario();
                List<string> respuestas = formulario.ObtenerRespuestas();
                float distancia = CalcularTipoInteligencia(respuestas).Item1;
                string tipoInteligencia = CalcularTipoInteligencia(respuestas).Item2;
                UsuariosTest miResult = new UsuariosTest();
                miResult.IntelligenceType = tipoInteligencia;
                miResult.Distance = distancia;
                miResult.nombre = user.usuario;
                List<UsuariosTest> usuarios = registroServicios.ObtenerUsuarios(distancia,tipoInteligencia, registroServicios.getuserId(user.usuario, user.contraseña));
                
                string imagenInteligencia = UrlDeInteligencia(tipoInteligencia);
                // Establecer el texto del control Label
                lblTipoInteligencia.Text = "Tu tipo de inteligencia es: " + tipoInteligencia;
                ImTipoInteligencia.ImageUrl = imagenInteligencia;
                rptPersonas.DataSource = usuarios;
                rptPersonas.DataBind();
                registroServicios.registrarUsuarioTest(miResult, user);
            }

        }
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_InfoToolsSV.aspx");
        }
     
        private static string UrlDeInteligencia(string intelignecia ) {
            switch (intelignecia) {
                case "espacial":
                    intelignecia = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Bruce_McCandless_II_during_EVA_in_1984.jpg/800px-Bruce_McCandless_II_during_EVA_in_1984.jpg";
                    break;
                case "musical":
                    intelignecia = "https://i0.wp.com/www.learningbp.com/wp-content/uploads/2022/01/stefany-andrade-GbSCAAsU2Fo-unsplash-1-scaled.jpg?resize=1140%2C760&ssl=1";
                    break;
                case "lingüístico-verbal":
                    intelignecia = "http://1.bp.blogspot.com/-1sg04rxt4gU/Vfl5vfu07-I/AAAAAAAAA-c/Vtk1UiiLyk4/s1600/aprender-idiomas_01.jpg";
                    break;
                case "lógico-matemático":
                    intelignecia = "https://neuroeducacionweb.net/wp-content/uploads/2019/03/Inteligencia-l%C3%B3gico-matem%C3%A1tica-700x385.jpg";
                    break;
                case "corporal cinestésico":
                    intelignecia = "https://www.lifeder.com/wp-content/uploads/2017/02/inteligencia-kinestesica-672x420.jpg";
                    break;
                case "intrapersonal":
                    intelignecia = "https://gestion.pe/resizer/BxhtH1VZ4ozxXwXeSgz4WQzhvDk=/580x330/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/B2S3QJ3J3JCPXF5BLE33W552T4.jpg";
                    break;
                case "interpersonal":
                    intelignecia = "https://www.psicoactiva.com/wp-content/uploads/2019/01/inteligencia-intepersonal.jpg";
                    break;
                case "naturalista":
                    intelignecia = "https://storage.googleapis.com/mv-prod-blog-es-assets-gcs/2019/07/rsz_a1_1-1-1024x683.jpg";
                    break;
                case "existencial":
                    intelignecia = "https://www.intelitest.net/wp-content/uploads/inteligencia-existencial.jpg";
                    break;

                case "creativo":
                    intelignecia = "https://cdn0.psicologia-online.com/es/posts/8/4/1/inteligencia_creativa_caracteristicas_ejemplos_y_como_desarrollarla_5148_600.webp";
                    break;
                case "emocional":
                    intelignecia = "https://gestion.pe/resizer/VSxp5kpahxElgwJq9P8ASU538m0=/580x330/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/65XIIQULEFCR3FAVIYS2A2JJUQ.jpg";
                    break;
                case "colaborativo":
                    intelignecia = "https://www.danielcolombo.com/wp-content/uploads/2020/02/inteligencia-colaborativa-personas-reunidas-mesa-trabajar-en-equipo-daniel-colombo.jpg";
                    break;
            }
            return intelignecia;
        }
        private static (float, string) CalcularTipoInteligencia(List<string> respuestas) // Algoritmo Euclides
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


            return (Convert.ToSingle(minDistancia), tipoInteligenciaPredominante);

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
