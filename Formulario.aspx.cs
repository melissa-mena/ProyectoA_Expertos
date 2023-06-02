using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            //"bg-pastel-yellow", "bg-pastel-pink", "bg-light"
            string[] colors = { "bg-pastel-pink", "bg-pastel-blue", "bg-pastel-green" };

            // Utiliza diferentes colores de fondo (bg-*) según el índice de la pregunta
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


        protected void btnEnviar_Click(object sender, EventArgs e)
            {
                // Procesar las respuestas enviadas por el usuario
                List<string> respuestas = new List<string>();

                foreach (RepeaterItem item in rptPreguntas.Items)
                {
                    var ddlRespuesta = (DropDownList)item.FindControl("ddlRespuesta");
                    respuestas.Add(ddlRespuesta.SelectedValue);
                }

                // Realizar cualquier acción necesaria con las respuestas enviadas
                // ...

                // Redirigir a otra página o mostrar un mensaje de éxito, etc.
                // ...
            }

            private void CargarPreguntas()
            {
                // Aquí puedes definir las preguntas y las opciones de respuesta para cada pregunta
                // Puedes usar una base de datos, una matriz, un diccionario, o cualquier otra estructura de datos para almacenar las preguntas y respuestas

                List<Pregunta> preguntas = new List<Pregunta>()
            {
                new Pregunta
                {
                    PreguntaText = "Pregunta 1",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 1.1", Valor = "1.1" },
                        new OpcionRespuesta { Texto = "Respuesta 1.2", Valor = "1.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 1
                    }
                },
                new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                   new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                      new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                         new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                            new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                               new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                  new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                     new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                        new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                           new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                              new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                 new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                    new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                       new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                          new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                             new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                                new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                                   new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                                      new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                                         new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                                            new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                                               new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                                                  new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                },
                                                                                     new Pregunta
                {
                    PreguntaText = "Pregunta 2",
                    OpcionesRespuesta = new List<OpcionRespuesta>
                    {
                        new OpcionRespuesta { Texto = "Respuesta 2.1", Valor = "2.1" },
                        new OpcionRespuesta { Texto = "Respuesta 2.2", Valor = "2.2" },
                        // Agrega aquí las opciones de respuesta para la pregunta 2
                    }
                    
                },
                // Agrega aquí las preguntas restantes
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
