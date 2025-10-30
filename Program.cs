using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNotificacao
{
    class Program
    {

        public class app 
        { 
                             
            static void Main(string[] args)  
            {
               Email email1 = new Email();               
               Console.WriteLine(email1.EnviarMensagem("oiiiiiiiiiii"));

                SMS sms1 = new SMS();
                Console.WriteLine(sms1.EnviarMensagem("oiiiiiiiiiiii"));

                Push push1 = new Push();
                Console.WriteLine(push1.EnviarMensagem("oiiiiiiiiiiii"));


            }

            public interface Mensagem
            {
             string EnviarMensagem(string mensagem);
            }


            public class Email : Mensagem
            {
                public string EnviarMensagem(string mensagem)
                {
                  
                    return $"Enviando E-mail: {mensagem}";
                }
                
            }

            public class SMS : Mensagem
            {

                public string EnviarMensagem(string mensagem)
                {
                
                return $"Enviado SMS: {mensagem}";    
                }

            }

            public class Push : Mensagem
            { 
                public string EnviarMensagem(string mensagem)    
                {
                 return $"Enviando push: {mensagem}";
                        
                } 
            }





            } 
        
    }
}
