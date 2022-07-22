using CapaDtoOperaciones;
using CapaEntidadIPS;
using CapaNegocioIPS;
using CapNegocioOperaciones;
using RestSharp;
using spe.gob.ec;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace spe.gob.ec
{
    public partial class frmMonitor : Form
    {

        public frmMonitor()
        {
            InitializeComponent();
        }

        private void frmMonitor_Load(object sender, EventArgs e)
        {
            
            SrvEventos srv = new SrvEventos();
            
           
            FnIniciarProceso();
            txtRutaArchivo.Text = Application.ExecutablePath;
            txtFrecuenciaEjecucion.Text = Math.Truncate((TimeSpan.FromMilliseconds(double.Parse(srv.Tiempo)).TotalMinutes * 100) / 100) + " minutos";
        }

        private void FnIniciarProceso()
        {
            SrvEventos srv = new SrvEventos();
            Timer MyTimer = new Timer
            {
                Interval = int.Parse(srv.Tiempo)
            };
            MyTimer.Enabled = true;
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            Resultado oResultado = new Resultado();
            SrvEventos srv = new SrvEventos();
            string strFecha;
            if (lstEventos.Items.Count >= 3000) lstEventos.Items.Clear();

            lstEventos.Items.Add(DateTime.Now.ToLongTimeString() + ", " + DateTime.Now.ToLongDateString() + " - Inicio del consumo del servicio");
            try
            {
                strFecha = System.DateTime.Now.ToShortTimeString();

                TimeSpan tsActual = DateTime.Parse(strFecha).TimeOfDay;
                TimeSpan tsInicio = DateTime.Parse(srv.HoraInicio).TimeOfDay;
                TimeSpan tsFin = DateTime.Parse(srv.HoraFin).TimeOfDay;

                if (tsActual > tsInicio && tsActual < tsFin)
                {
                    EnvioOpeCN oEnvioOpeCN = new EnvioOpeCN();
                    List<Op_Envio> oListaEnvios = new List<Op_Envio>();
                    oListaEnvios = oEnvioOpeCN.FnConsultar();


                    EnvioCN oEnvioCN = new EnvioCN();
                    EnvioEventoDto oEnvio = new EnvioEventoDto();

                    if (oListaEnvios.Count==0)
                    {
                        lstEventos.Items.Add(DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString() + " - No existen registros pendientes de procesar");
                        return;
                    }


                    foreach (Op_Envio oEnvioOP in oListaEnvios)
                    {

                        oEnvio.Codigo_de_envio_SPE = oEnvioOP.codigo_envio;
                        oEnvio.Numero_guia_servi = oEnvioOP.codigo_operador;
                        oEnvio.Nombre_movimiento = oEnvioOP.evento;
                        oEnvio.Fecha_movimiento = Convert.ToDateTime(oEnvioOP.fecha_evento);
                        oEnvio.Observacion_movimiento = oEnvioOP.observacion;
                        oEnvio.Movimiento_Entrega_NoEntrega = oEnvioOP.movimiento_entrega_noentrega;
                        oEnvio.Geolocalizacion_Movimiento_Entrega_NoEntrega = oEnvioOP.geolocalizacion_movimiento_entrega_noentrega;
                        oEnvio.Locacion = oEnvioOP.locacion;
                        oResultado = oEnvioCN.FnRegistrarGestionIPS(oEnvio, oEnvioOP.id);
                        lstEventos.Items.Add(DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString() + " - " + oEnvio.Codigo_de_envio_SPE + " Resultado: " + oResultado.Mensaje);



                        if (oResultado.Codigo <= 0)
                        {
                            oEnvioOP.estado = -1;
                            oEnvioOP.log = oResultado.Mensaje;
                            oEnvioOpeCN.FnActualizar(oEnvioOP);
                        }
                        
                    }
                   
                    
                }
            }
            catch (Exception ex)
            {
                lstEventos.Items.Add(DateTime.Now.ToLongTimeString() + "," + DateTime.Now.ToLongDateString() + " - Ha ocurrido problemas en el consumo del servicio: " + ex.Message);
            }
        }

        

        
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            MyTimer_Tick(null, null);
        }

        private void lstEventos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
