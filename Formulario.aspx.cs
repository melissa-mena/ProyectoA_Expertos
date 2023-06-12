using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Login_InfoToolsSV
{
    public partial class Formulario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPreguntas();
            }
        }

        protected string GetCardColor(int index)
        {
         
            string[] colors = { "bg-pastel-pink", "bg-pastel-blue", "bg-pastel-green" };

            return colors[index % colors.Length];
        }
        protected void rptPreguntas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var pregunta = (Pregunta)e.Item.DataItem;
                var ddlRespuesta = (DropDownList)e.Item.FindControl("ddlRespuesta");

                // Cargar las opciones de respuesta para cada pregunta
                ddlRespuesta.DataSource = pregunta.OpcionesRespuesta;
                ddlRespuesta.DataTextField = "Texto";
                ddlRespuesta.DataValueField = "Valor";
                ddlRespuesta.DataBind();
            }
        }
        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_InfoToolsSV.aspx");
        }


        //protected void btnEnviar_Click(object sender, EventArgs e)
        //{
        //    List<string> respuestas = new List<string>();

        //    foreach (RepeaterItem item in rptPreguntas.Items)
        //    {
        //        var ddlRespuesta = (DropDownList)item.FindControl("ddlRespuesta");
        //        respuestas.Add(ddlRespuesta.SelectedValue);
        //    }
        //    Session["Respuestas"] = respuestas;
        //    Response.Redirect("VerResultado.aspx");
        //}
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            bool hasError = false;

            foreach (RepeaterItem item in rptPreguntas.Items)
            {
                var ddlRespuesta = (DropDownList)item.FindControl("ddlRespuesta");
                if (ddlRespuesta.SelectedValue == "")
                {
                    ddlRespuesta.CssClass += " alert-danger";
                    hasError = true;
                }
                else
                {
                    ddlRespuesta.CssClass = ddlRespuesta.CssClass.Replace(" alert-danger", "");
                }
            }
            if (hasError)
            {
                string script = @"var alertElement = document.createElement('div');
                      alertElement.className = 'alert alert-danger alert-dismissible fade show';
                      alertElement.innerHTML = '<button type=""button"" class=""close"" data-dismiss=""alert"" onclick=""closeAlert()"" >&times;</button>'
                                              + '<strong>¡Error!</strong> Por favor, selecciona una opción válida.';
                      alertElement.style.position = 'fixed';
                      alertElement.style.top = '0';
                      alertElement.style.left = '0';
                      alertElement.style.right = '0';
                      alertElement.style.textAlign = 'center';
                      document.body.appendChild(alertElement);

                      function closeAlert() {
                          alertElement.style.display = 'none';
                      }";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorPopup", script, true);
                return;
            }
            List<string> respuestas = new List<string>();

            foreach (RepeaterItem item in rptPreguntas.Items)
            {
                var ddlRespuesta = (DropDownList)item.FindControl("ddlRespuesta");
                respuestas.Add(ddlRespuesta.SelectedValue);
            }

            Session["Respuestas"] = respuestas;
            Response.Redirect("VerResultado.aspx");
        }


        public  List<string> ObtenerRespuestas()
        {
            List<string> resultado = Session["Respuestas"] as List<string>;

            if (resultado == null)
            {
                resultado = new List<string>();
            }

            return resultado;
        }
        private void CargarPreguntas()
        {

            List<Pregunta> preguntas = new List<Pregunta>()
            {
                new Pregunta
                {
                    PreguntaText = "¿Puedo recordar con precisión la ubicación de objetos o lugares específicos en un entorno familiar?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Tengo facilidad para resolver rompecabezas espaciales como el cubo de Rubik u otros juegos similares?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Tengo una habilidad destacada para reconocer patrones visuales en imágenes o diagramas complejos?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "Percibes patrones rítmicos en situaciones cotidianas, como el sonido de los pasos de las personas o el ritmo de la lluvia?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Puedes recordar con facilidad melodías o canciones completas después de escucharlas solo una vez?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Disfrutas explorar y descubrir nuevos géneros musicales o estilos que nunca antes habías escuchado?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Disfrutas leer libros y revistas?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
               new Pregunta
                {
                    PreguntaText = "¿Sientes que tienes habilidades para aprender nuevos idiomas rápidamente?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Disfrutas participar en debates o discusiones sobre temas diversos?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Sueles utilizar estrategias matemáticas para resolver situaciones cotidianas?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
               new Pregunta
                {
                    PreguntaText = "¿Sueles utilizar razonamiento matemático para tomar decisiones o resolver situaciones complejas?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Te sientes cómodo/a resolviendo acertijos y juegos de lógica?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Tienes habilidades para realizar movimientos precisos y coordinados con tu cuerpo?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Te resulta fácil aprender nuevas habilidades físicas, como jugar un deporte o tocar un instrumento musical?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Disfrutas bailar, actuar o participar en actividades que involucren el movimiento del cuerpo?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
               new Pregunta
                {
                    PreguntaText = "¿Reflexiono sobre mis pensamientos y emociones?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
               new Pregunta
                {
                    PreguntaText = "¿Tomo el tiempo para reflexionar sobre mis metas y propósitos en la vida?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
               new Pregunta
                {
                    PreguntaText = "¿Confío en mi intuición para tomar decisiones importantes en mi vida?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Te resulta fácil entender las emociones y sentimientos de los demás?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Tienes facilidad para establecer y mantener relaciones sólidas y armoniosas con los demás?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
               new Pregunta
                {
                    PreguntaText = "¿Tienes facilidad para resolver conflictos y mediar en situaciones de tensión entre personas?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Disfrutas pasar tiempo al aire libre y en contacto con la naturaleza?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Te sientes atraído/a por actividades como la jardinería, la agricultura o la observación de aves?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Sientes una conexión especial con el entorno natural y te preocupa su conservación?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Qué tan a menudo te preguntas sobre el propósito y el significado de la vida?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Alguna vez te has sentido conectado con algo más grande que tú mismo/a,\n como una fuerza espiritual o energía universal?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
               new Pregunta
                {
                    PreguntaText = "¿Sientes curiosidad por comprender el significado y el propósito de la existencia humana?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Consideras que la expresión creativa es una parte esencial de la experiencia humana y una forma \n de encontrar significado en la vida?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Sueles utilizar métodos no convencionales o fuera de lo común para resolver problemas o abordar situaciones?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Te sientes cómodo/a tomando riesgos o explorando ideas poco convencionales en tus proyectos o actividades creativas?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Utilizas tus emociones como fuente de inspiración para tus proyectos?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Te resulta difícil manejar tus propias emociones en situaciones estresantes?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Sueles mostrar empatía hacia los sentimientos y experiencias de los demás?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Estás dispuesto/a a compartir los créditos y reconocimientos por los logros alcanzados en proyectos colaborativos,\n" +
                                   " prefiriendo destacar tu propia contribución?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
                new Pregunta
                {
                    PreguntaText = "¿Buscas oportunidades para liderar y organizar proyectos en colaboración con tus compañeros, \n " +
                                    "aprovechando las fortalezas individuales para lograr metas comunes?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
               new Pregunta
                {
                    PreguntaText = "¿Consideras las opiniones y perspectivas de tus compañeros antes de tomar decisiones importantes?",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Siempre", Valor = "Siempre" },
                        new OpcionRespuesta { Texto = "A veces", Valor = "A veces" },
                        new OpcionRespuesta { Texto = "Nunca", Valor = "Nunca" },
                    }
                },
   
            };

            rptPreguntas.DataSource = preguntas;
            rptPreguntas.DataBind();
        }
    }

    public class Pregunta
    {
        public string PreguntaText { get; set; }
        public List<OpcionRespuesta> OpcionesRespuesta { get; set; }
    }

    public class OpcionRespuesta
    {
        public string Texto { get; set; }
        public string Valor { get; set; }
    }
}
