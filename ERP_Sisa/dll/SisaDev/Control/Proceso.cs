// Decompiled with JetBrains decompiler
// Type: SisaDev.Control.Proceso
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using SisaDev.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace SisaDev.Control
{
  public class Proceso
  {
    public static tblUsuarios usuarioGlobal;
    public static tblRolesUsuarios rolesUsuariosGlobal;

    public static string EncriptaClave(string Pasword)
    {
      string empty = string.Empty;
      for (int startIndex = 0; startIndex < Pasword.Length; ++startIndex)
      {
        char c = Convert.ToChar(Pasword.Substring(startIndex, 1));
        if (char.IsNumber(c))
        {
          int num = (int) c;
          empty += num.ToString();
        }
        else if (char.IsLetter(c))
        {
          int num = (int) c;
          empty += num.ToString();
        }
        else
        {
          int num = (int) c;
          empty += num.ToString();
        }
      }
      if (empty.Length < 36)
      {
        while (empty.Length < 36)
          empty += "0";
      }
      byte[] hash;
      using (MD5 md5 = MD5.Create())
        hash = md5.ComputeHash(Encoding.UTF8.GetBytes(empty));
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < hash.Length; ++index)
        stringBuilder.Append(hash[index].ToString("x2"));
      return stringBuilder.ToString();
    }

    public static string GeneraCodigoRecuperacion()
    {
      string empty = string.Empty;
      return Guid.NewGuid().ToString().Substring(25, 10);
    }

    public static bool EnviarCorreo(string pCorreo, string pCodigo)
    {
      try
      {
        MailMessage message = new MailMessage();
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.office365.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = (ICredentialsByHost) new NetworkCredential("rvalencia@sistemasautomatizados.net", "121314_sisa");
        message.To.Add(new MailAddress(pCorreo));
        message.From = new MailAddress("rvalencia@sistemasautomatizados.net");
        message.Subject = "Asunto ( Codigo de restauración ) ";
        message.Body = " " + pCodigo;
        message.IsBodyHtml = true;
        smtpClient.Send(message);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public static bool EnviarCorreoDocs(
      string to,
      string pBody,
      string from,
      string asunto,
      string attch,
      string cc)
    {
      try
      {
        MailMessage message = new MailMessage();
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "secure.emailsrvr.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = (ICredentialsByHost) new NetworkCredential("contacto@sistemasautomatizados.net", "Sisa_2021.co");
        message.To.Add(new MailAddress(to));
        message.From = new MailAddress(from);
        message.Sender = new MailAddress(from);
        string[] strArray = cc.Split(';');
        if (cc.Length > 0 && strArray.Length != 0)
        {
          for (int index = 0; index < strArray.Length; ++index)
            message.CC.Add(strArray[index]);
        }
        message.Bcc.Add("lromo@sistemasautomatizados.net");
        message.Bcc.Add("mduran@sistemasautomatizados.net");
        message.Subject = asunto;
        message.Body = " " + pBody;
        message.IsBodyHtml = true;
        if (!string.IsNullOrEmpty(attch))
          message.Attachments.Add(new Attachment(attch, "application/octet-stream"));
        smtpClient.Send(message);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}
