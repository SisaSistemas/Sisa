using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using SisaDev.Models;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace SisaDev.Control
{
    

    public class Proceso
    {

        static HttpClient client = new HttpClient();

        public static tblUsuarios usuarioGlobal;
        public static tblRolesUsuarios rolesUsuariosGlobal;

        public static tblClienteContacto contactoGlobal;
        public static tblRolesContactos rolesContactosGlobal;
        public static string EncriptaClave(string Pasword)
        {
            string Retorno = string.Empty;
            char caracter;

            for (int i = 0; i < Pasword.Length; i++)
            {
                caracter = Convert.ToChar(Pasword.Substring(i, 1));

                if (Char.IsNumber(caracter)) //numero
                {
                    int a = (char)caracter;
                    Retorno = Retorno + a.ToString();
                }
                else if (Char.IsLetter(caracter)) // letra
                {
                    int a = (char)caracter;
                    Retorno = Retorno + a.ToString();
                }
                else //simbolo
                {
                    int a = (char)caracter;
                    Retorno = Retorno + a.ToString();
                }
            }
            if (Retorno.Length < 36)
            {
                while (Retorno.Length < 36)
                {
                    Retorno = Retorno + "0";
                }
            }

            byte[] data;
            using (MD5 md5Hash = MD5.Create())
            {
                data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(Retorno));
            }
            StringBuilder sBuilder = new StringBuilder();

            // formatear cada byte a hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public static string GeneraCodigoRecuperacion()
        {
            string retorno = string.Empty;  
            retorno = Guid.NewGuid().ToString().Substring(25,10);
            return retorno;
        }

        public static bool EnviarCorreoAsync(string pCorreo, string pCodigo)
        {
            bool retorno = false;
            //try
            //{
            var uri = "http://187.188.250.26/apiSendEmail/api/Email";
            uri += $"/?ToEmail={pCorreo}&Subjet=Asunto (Codigo de restauración )&Body={pCodigo}&Attachments=";

            var responseTask = client.GetAsync(uri);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                retorno = true;
            }
            //HttpResponseMessage httpResponseMessage = await client.GetAsync(uri);
            //if (httpResponseMessage.IsSuccessStatusCode)
            //{
            //    var content = await httpResponseMessage.Content.ReadAsStringAsync();
            //    return content;
            //}

            //}
            //catch (Exception)
            //{

            //}

            return retorno;
        }
        
        public static bool EnviarCorreo(string pCorreo, string pCodigo)
        {
            bool retorno = false;

            //try
            //{
            //    var uri = "http://187.188.250.26/apiSendEmail/api/Email";
            //    uri += $"/?ToEmail={pCorreo}&Subjet=Asunto (Codigo de restauración )&Body={pCodigo}&Attachments=";

            //    HttpResponseMessage httpResponseMessage = await client.GetAsync(uri);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //try
            //{
            //    var message = new MimeMessage();
            //    message.From.Add(new MailboxAddress("Luis Carlos Galvez", "lgalvez@sistemasautomatizados.net"));
            //    message.To.Add(new MailboxAddress("", pCorreo));
            //    message.Subject = "Asunto ( Codigo de restauración ) ";

            //    message.Body = new TextPart("plain")
            //    {
            //        Text = @" " + pCodigo
            //    };

            //    using (var client = new MailKit.Net.Smtp.SmtpClient())
            //    {
            //        client.Connect("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            //        // Note: only needed if the SMTP server requires authentication
            //        client.Authenticate("lgalvez@sistemasautomatizados.net", "Luisk0304");

            //        client.Send(message);
            //        client.Disconnect(true);

            //    }
            //    retorno = true;
            //}
            //catch (Exception ex)
            //{
            //    retorno = false;
            //}

            try
            {

                MailMessage mail = new MailMessage();
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = "secure.emailsrvr.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("contacto@sistemasautomatizados.net", "Sisa_2021.co");
                mail.To.Add(new MailAddress(pCorreo));
                mail.From = new MailAddress("lgalvez@sistemasautomatizados.net");
                mail.Subject = "Asunto ( Codigo de restauración ) ";
                mail.Body = " " + pCodigo;
                mail.IsBodyHtml = true;

                smtp.Send(mail);

                retorno = true;
            }
            catch (Exception x)
            {
                retorno = false;
            }
            return retorno;
        }

        public static bool EnviarCorreoDocsOffice(string to, string pBody, string nombreFrom, string from, string asunto, List<string> attch, string cc, string Sucursal )
        {
            bool retorno = false;

            try
            {
                var fromPrueba = new MailboxAddress(name: nombreFrom, address: "no_reply@sistemasautomatizados.net");
                //var toPrueba = new MailboxAddress(name: to, address: to);


                var msj = new MimeMessage();
                msj.From.Add(fromPrueba);

                //msj.To.Add(toPrueba);
                string[] toList = to.Split(';');
                if (to.Length > 0)
                {
                    if (toList.Length > 0)
                    {
                        for (int i = 0; i < toList.Length; i++)
                        {
                            msj.To.Add(new MailboxAddress(name: toList[i], address: toList[i].Trim()));
                        }
                    }
                }

                string[] acc = cc.Split(';');
                if (cc.Length > 0)
                {
                    if (acc.Length > 0)
                    {
                        for (int i = 0; i < acc.Length; i++)
                        {
                            msj.Cc.Add(new MailboxAddress(name: acc[i], address: acc[i].Trim()));
                        }
                    }
                }

                msj.Bcc.Add(new MailboxAddress(name: "Lilia Romo", address: "lromo@sistemasautomatizados.net"));

                msj.Subject = asunto;
                //msj.Body = new TextPart(pBody);
                //msj.HtmlBody = pBody;

                //HERMOSILLO
                if (Sucursal.ToUpper() == "E9D0B53B-D8B7-493A-B26D-FAF66D906157")
                {
                    msj.Bcc.Add(new MailboxAddress(name: "Angelica Romero", address: "aromero@sistemasautomatizados.net"));
                    msj.Bcc.Add(new MailboxAddress(name: "Abigail Roman", address: "aroman@sistemasautomatizados.net"));
                    msj.Bcc.Add(new MailboxAddress(name: "Maria Duran", address: "mduran@sistemasautomatizados.net"));
                }
                else if (Sucursal.ToUpper() == "4327A1A3-B1F1-438A-9C89-081B2FB69D08")
                {
                    //CHIHUAHUA
                    msj.Bcc.Add(new MailboxAddress(name: "Cecilia Piñon", address: "cpinon@sistemasautomatizados.net"));
                    msj.Bcc.Add(new MailboxAddress(name: "Maria Duran", address: "mduran@sistemasautomatizados.net"));
                }
                else if (Sucursal.ToUpper() == "E8FB7D08-3E75-4DD4-9D6F-18A31886B638")
                {
                    //CUAUTITLAN
                    msj.Bcc.Add(new MailboxAddress(name: "Eduardo Ibañez", address: "eibanez@sistemasautomatizados.net"));
                    msj.Bcc.Add(new MailboxAddress(name: "Cristina Rabago", address: "crabago@sistemasautomatizados.net"));
                }
                else if (Sucursal.ToUpper() == "1479126E-06FA-4F4B-BA36-380CF73A6912")
                {
                    //QUERETARO
                    msj.Bcc.Add(new MailboxAddress(name: "Yolanda Calderon", address: "ycalderon@sistemasautomatizados.net"));
                    msj.Bcc.Add(new MailboxAddress(name: "Adriana Vargas", address: "avargas@sistemasautomatizados.net"));
                }
                else if (Sucursal.ToUpper() == "AED5D6F1-86F9-4148-8A45-F97F4AD140A5")
                {
                    //IRAPUATO
                    msj.Bcc.Add(new MailboxAddress(name: "Angelica Romero", address: "aromero@sistemasautomatizados.net"));
                    msj.Bcc.Add(new MailboxAddress(name: "Abigail Roman", address: "aroman@sistemasautomatizados.net"));
                    msj.Bcc.Add(new MailboxAddress(name: "Cristina Rabago", address: "crabago@sistemasautomatizados.net"));
                }
                else if (Sucursal.ToUpper() == "56A03C71-BF9B-48E1-ABE0-D32A95B5FBDB")
                {
                    //USA
                    msj.Bcc.Add(new MailboxAddress(name: "Angelica Romero", address: "aromero@sistemasautomatizados.net"));
                    msj.Bcc.Add(new MailboxAddress(name: "Abigail Roman", address: "aroman@sistemasautomatizados.net"));
                    msj.Bcc.Add(new MailboxAddress(name: "Cristina Rabago", address: "crabago@sistemasautomatizados.net"));
                }
                else if (Sucursal.ToUpper() == "F8E5400A-E1B5-4100-A990-E73E9DA59370")
                {
                    //TECATE
                    msj.Bcc.Add(new MailboxAddress(name: "Cristal Zazueta", address: "czazueta@sistemasautomatizados.net"));
                }

                msj.Bcc.Add(new MailboxAddress(name: nombreFrom, address: from));
                //mail.Bcc.Add("mduran@sistemasautomatizados.net");
                var builder = new BodyBuilder()
                {
                    HtmlBody = pBody
                };

                if (attch.Count > 0)
                {
                    foreach (var file in attch)
                    {
                        builder.Attachments.Add(file);
                    }
                }

                msj.Body = builder.ToMessageBody();

                var client = new MailKit.Net.Smtp.SmtpClient();

                client.Connect(host: "smtp.office365.com", port: 587, options: MailKit.Security.SecureSocketOptions.StartTls);

                //client.Connect(host: "sistemasautomatizados-net.mail.protection.outlook.com", port: 25);

                //https://support.microsoft.com/es-es/account-billing/uso-de-contrase%C3%B1as-de-la-aplicaci%C3%B3n-con-aplicaciones-que-no-admiten-la-verificaci%C3%B3n-en-dos-pasos-5896ed9b-4263-e681-128a-a6f2979a7944
                //client.Authenticate("nominas@sistemasautomatizados.net", "Sisa.2023");
                client.Authenticate("no_reply@sistemasautomatizados.net", "Sisa.2025");

                //client.Authenticate()
                client.Send(msj);

                client.Disconnect(true);
                retorno = true;
            }
            catch (Exception x)
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool EnviarCorreoDocs(string to, string pBody, string nombreFrom, string from, string asunto, List<string> attch, string cc, string Sucursal)
        {
            bool retorno = false;

            //var uri = "http://187.188.250.26/apiSendEmail/api/Email";
            //var uri = "https://localhost:5001/api/Email";
            //////uri += $"/?ToEmail={to}&Subjet={asunto}&Body={pBody}&Attachments=";

            //var fileStream = new FileStream(attch[0], FileMode.Open);
            ////var fileName = Path.GetFileName(attch[0]);

            ////var streamContent = new StreamContent(fileStream);
            ////var fileContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);


            //var content = new MultipartFormDataContent();
            //////data.Headers.Add("Content-Type", "multipart/form-data");

            ////data.Add(new StringContent(to), "ToBody");
            ////data.Add(new StringContent(asunto), "Subjet");
            ////data.Add(new StringContent(pBody), "Body");
            //////data.Add(fileContent, "attachments", attch[0]);
            ////data.Add(new StreamContent(fileStream), "attachments", fileName);
            //byte[] data;

            //MemoryStream memoryStream = new MemoryStream();
            //fileStream.CopyTo(memoryStream);
            //data = memoryStream.ToArray();

            //ByteArrayContent byteContent = new ByteArrayContent(data);
            //byteContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");
            //byteContent.Headers.ContentDisposition.Name = "ToBody";
            //byteContent.Headers.ContentDisposition.

            //var response = client.PostAsync(uri, content);
            //response.Wait();

            //var result = response.Result;
            //if (result.IsSuccessStatusCode)
            //{

            //}
            //client.Dispose();

            //var responseTask = client.GetAsync(uri);
            //responseTask.Wait();

            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsStringAsync();
            //    retorno = true;
            //}

            try
            {
                //var message = new MimeMessage();
                //message.From.Add(new MailboxAddress(nombreFrom, from));
                //message.To.Add(new MailboxAddress("", to));
                //message.Subject = asunto;

                ////message.Sender.Address(from);

                //string[] acc = cc.Split(';');

                //if (cc.Length > 0)
                //{
                //    if (acc.Length > 0)
                //    {
                //        for (int i = 0; i < acc.Length; i++)
                //        {
                //            message.Cc.Add(new MailboxAddress("", acc[i]));
                //        }
                //    }
                //}

                ////message.Bcc.Add(new MailboxAddress("Lilia Romo", "lromo@sistemasautomatizados.net"));
                ////message.Bcc.Add(new MailboxAddress("Maria Duran", "mduran@sistemasautomatizados.net"));
                ////message.Bcc.Add(new MailboxAddress("Angelica Romero", "aromero@sistemasautomatizados.net"));
                ////message.Bcc.Add(new MailboxAddress("Abigail Roman", "aroman@sistemasautomatizados.net"));

                //var builder = new BodyBuilder();

                //builder.HtmlBody = "" + pBody;

                //if (attch.Count > 0)
                //{
                //    foreach (var file in attch)
                //    {
                //        builder.Attachments.Add(file);
                //    }
                //}

                //message.Body = builder.ToMessageBody();

                ////message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                ////{
                ////    Text = @" " + pBody
                ////};

                //using (var client = new MailKit.Net.Smtp.SmtpClient())
                //{
                //    client.Connect("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

                //    // Note: only needed if the SMTP server requires authentication
                //    client.Authenticate("no_reply@sistemasautomatizados.net", "$iSa.2021");
                //    //client.Authenticate("lgalvez@sistemasautomatizados.net", "Luisk0304");

                //    client.Send(message);
                //    client.Disconnect(true);

                //}

                MailMessage mail = new MailMessage();
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = "secure.emailsrvr.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("contacto@sistemasautomatizados.net", "Sisa_2021.co");
                //mail.To.Add(new MailAddress(to));

                string[] toList = to.Split(';');
                if (to.Length > 0)
                {
                    if (toList.Length > 0)
                    {
                        for (int i = 0; i < toList.Length; i++)
                        {
                            mail.To.Add(toList[i]);
                        }
                    }
                }

                mail.From = new MailAddress(from);

                mail.Sender = new MailAddress(from);
                string[] acc = cc.Split(';');
                if (cc.Length > 0)
                {
                    if (acc.Length > 0)
                    {
                        for (int i = 0; i < acc.Length; i++)
                        {
                            mail.CC.Add(acc[i]);
                        }
                    }
                }

                mail.Bcc.Add("lromo@sistemasautomatizados.net");

                //HERMOSILLO
                if (Sucursal.ToUpper() == "E9D0B53B-D8B7-493A-B26D-FAF66D906157")
                {
                    mail.Bcc.Add("aromero@sistemasautomatizados.net");
                    mail.Bcc.Add("aroman@sistemasautomatizados.net");
                    mail.Bcc.Add("mduran@sistemasautomatizados.net");
                } 
                else if (Sucursal.ToUpper() == "4327A1A3-B1F1-438A-9C89-081B2FB69D08")
                {
                    //CHIHUAHUA
                    mail.Bcc.Add("cpinon@sistemasautomatizados.net");
                    mail.Bcc.Add("mduran@sistemasautomatizados.net");
                } 
                else if (Sucursal.ToUpper() == "E8FB7D08-3E75-4DD4-9D6F-18A31886B638")
                {
                    //CUAUTITLAN
                    mail.Bcc.Add("eibanez@sistemasautomatizados.net");
                    mail.Bcc.Add("crabago@sistemasautomatizados.net");
                }
                else if (Sucursal.ToUpper() == "1479126E-06FA-4F4B-BA36-380CF73A6912")
                {
                    //QUERETARO
                    mail.Bcc.Add("ycalderon@sistemasautomatizados.net");
                    mail.Bcc.Add("avargas@sistemasautomatizados.net");
                }
                else if (Sucursal.ToUpper() == "AED5D6F1-86F9-4148-8A45-F97F4AD140A5")
                {
                    //IRAPUATO
                    mail.Bcc.Add("aromero@sistemasautomatizados.net");
                    mail.Bcc.Add("aroman@sistemasautomatizados.net");
                    mail.Bcc.Add("crabago@sistemasautomatizados.net");
                }
                else if (Sucursal.ToUpper() == "56A03C71-BF9B-48E1-ABE0-D32A95B5FBDB")
                {
                    //USA
                    mail.Bcc.Add("aromero@sistemasautomatizados.net");
                    mail.Bcc.Add("aroman@sistemasautomatizados.net");
                    mail.Bcc.Add("crabago@sistemasautomatizados.net");
                }
                else if (Sucursal.ToUpper() == "F8E5400A-E1B5-4100-A990-E73E9DA59370")
                {
                    //TECATE
                    mail.Bcc.Add("czazueta@sistemasautomatizados.net");
                    //mail.Bcc.Add("aroman@sistemasautomatizados.net");
                    //mail.Bcc.Add("mduran@sistemasautomatizados.net");
                }

                mail.Bcc.Add(from);
                //mail.Bcc.Add("mduran@sistemasautomatizados.net");
               

                mail.Subject = asunto;
                mail.Body = " " + pBody;
                mail.IsBodyHtml = true;

                if (attch.Count > 0)
                {
                    foreach (var file in attch)
                    {
                        mail.Attachments.Add(new Attachment(file, MediaTypeNames.Application.Octet));
                    }
                }

                //if (!string.IsNullOrEmpty(attch))
                //{
                //    mail.Attachments.Add(new System.Net.Mail.Attachment(attch, MediaTypeNames.Application.Octet));
                //}
                smtp.Send(mail);

                retorno = true;
            }
            catch (Exception x)
            {
                retorno = false;
            }
            return retorno;
        }

        public static bool EnviarCorreoProyecto(string to, string pBody, string from, string asunto)
        {
            bool retorno = false;
            try
            {
                //var message = new MimeMessage();
                //message.From.Add(new MailboxAddress("", from));
                //message.To.Add(new MailboxAddress("", to));
                //message.Subject = asunto;

                //message.Cc.Add(new MailboxAddress("", "gerencia@sistemasautomatizados.net"));
                //message.Bcc.Add(new MailboxAddress("Luis Carlos Galvez", "lgalvez@sistemasautomatizados.net"));

                //var builder = new BodyBuilder();

                //builder.HtmlBody = "" + pBody;

                //message.Body = builder.ToMessageBody();

                //using (var client = new MailKit.Net.Smtp.SmtpClient())
                //{
                //    client.Connect("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

                //    // Note: only needed if the SMTP server requires authentication
                //    client.Authenticate("lgalvez@sistemasautomatizados.net", "Luisk0304");

                //    client.Send(message);
                //    client.Disconnect(true);

                //}

                //MailMessage mail = new MailMessage();
                //System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                //smtp.Host = "secure.emailsrvr.com";
                //smtp.Port = 587;
                //smtp.EnableSsl = true;

                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new NetworkCredential("contacto@sistemasautomatizados.net", "Sisa_2021.co");
                //mail.To.Add(new MailAddress(to));
                //mail.From = new MailAddress(from);

                //mail.Sender = new MailAddress(from);
                //mail.CC.Add(new MailAddress("gerencia@sistemasautomatizados.net"));

                //mail.Bcc.Add("lgalvez@sistemasautomatizados.net");
                ////mail.Bcc.Add("mduran@sistemasautomatizados.net");
                ////mail.Bcc.Add("aromero@sistemasautomatizados.net");

                //mail.Subject = asunto;
                //mail.Body = " " + pBody;
                //mail.IsBodyHtml = true;

                //smtp.Send(mail);

                //retorno = true;

                var fromPrueba = new MailboxAddress(name: "No Reply", address: "no_reply@sistemasautomatizados.net");
                var toPrueba = new MailboxAddress(name: to, address: to);


                var msj = new MimeMessage();
                msj.From.Add(fromPrueba);
                msj.To.Add(toPrueba);

                msj.Cc.Add(new MailboxAddress(name: "Gerencia", address: "gerencia@sistemasautomatizados.net"));
                msj.Bcc.Add(new MailboxAddress(name: "Luis Carlos Galvez", address: "lgalvez@sistemasautomatizados.net"));

                msj.Subject = asunto;
                //msj.Body = " " + pBody;

                //var body = new TextPart("plain")
                //{
                //    Text = " " + pBody
                //};

                var builder = new BodyBuilder()
                {
                    HtmlBody = pBody
                };

                //var multipart = new Multipart("mixed");
                //multipart.Add(body);
                //multipart.Add(attachment);
                msj.Body = builder.ToMessageBody();
                //msj.Body = multipart;

                var client = new MailKit.Net.Smtp.SmtpClient();

                client.Connect(host: "smtp.office365.com", port: 587, options: MailKit.Security.SecureSocketOptions.StartTls);
                
                //client.Connect(host: "sistemasautomatizados-net.mail.protection.outlook.com", port: 25);

                //https://support.microsoft.com/es-es/account-billing/uso-de-contrase%C3%B1as-de-la-aplicaci%C3%B3n-con-aplicaciones-que-no-admiten-la-verificaci%C3%B3n-en-dos-pasos-5896ed9b-4263-e681-128a-a6f2979a7944
                //client.Authenticate("nominas@sistemasautomatizados.net", "Sisa.2023");
                client.Authenticate("no_reply@sistemasautomatizados.net", "Sisa.2025");

                //client.Authenticate()
                client.Send(msj);

                client.Disconnect(true);
                retorno = true;
            }
            catch (Exception x)
            {
                retorno = false;
            }
            return retorno;
        }

        public static bool EnviarCorreoCCM(string to, string pBody, string from, string asunto, string plantaCCM, string correoPM, List<string> correoGerencia)
        {
            bool retorno = false;
            try
            { 
                MailMessage mail = new MailMessage();
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = "secure.emailsrvr.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("contacto@sistemasautomatizados.net", "Sisa_2021.co");
                mail.To.Add(new MailAddress(to));
                mail.To.Add(new MailAddress(correoPM));

                mail.From = new MailAddress(from);

                mail.Sender = new MailAddress(from);
                foreach (var item in correoGerencia)
                {
                    mail.CC.Add(new MailAddress(item));
                }
                //mail.CC.Add(new MailAddress("jduran@sistemasautomatizados.net"));
                //mail.CC.Add(new MailAddress("mromero@sistemasautomatizados.net"));

                //mail.Bcc.Add("lgalvez@sistemasautomatizados.net");

                mail.Subject = asunto;
                mail.Body = " " + pBody;
                mail.IsBodyHtml = true;

                smtp.Send(mail);

                retorno = true;
            }
            catch (Exception x)
            {
                retorno = false;
            }

            return retorno;
        }
    }
}