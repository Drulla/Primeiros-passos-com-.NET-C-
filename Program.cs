using System;

namespace Revisão
{
    class Program
    {
        static void Main(string[] args)
        {

            aluno[] alunos = new aluno[5];
            var IndiceAluno =0;
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //TODO: adicionar aluno
                        Console.WriteLine("Informe o nome do aluno: ");
                        var  aluno = new aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[IndiceAluno] = aluno;
                        IndiceAluno ++;
                        
                        break;

                    case "2":
                        //Listar alunos
                        foreach(var a in alunos)
                        {   
                           // if(!a.Nome.Equals("")) //"!" < para negar a equação, ou seja, não ira trazer posição vazio, sendo que o array é de 5 posições
                           if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}");
                            }
                            
                        }
                        break;

                    case "3":
                        // Calcular media geral
                        decimal notaTotal =0;
                        var nrALunos = 0;

                        for (int i=0; i<alunos.Length; i++)
                        {
                            if (!String.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrALunos++;
                            }
                        }
                        
                        var mediaGeral = notaTotal/ nrALunos;
                        ConceitoEnum ConceitoGeral;
                        
                        if (mediaGeral < 2)
                        {
                            ConceitoGeral = ConceitoEnum.E;
                        }
                        else if(mediaGeral < 4)
                        {
                           ConceitoGeral = ConceitoEnum.D; 
                        }
                        else if(mediaGeral < 6)
                        {
                           ConceitoGeral = ConceitoEnum.C; 
                        }
                        else if(mediaGeral < 8)
                        {
                           ConceitoGeral = ConceitoEnum.B; 
                        }
                        else
                        {
                             ConceitoGeral = ConceitoEnum.A; 
                        }
                       
                        Console.WriteLine($"MEDIA GERAL: {mediaGeral} - CONCEITO {ConceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = obterOpcaoUsuario();
            }

        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
