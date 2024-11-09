using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Runtime.CompilerServices;


//using System.Windows.Forms.DataVisualization.Charting;

namespace graficoDeTemperatura_2
{
    public partial class Form1 : Form
    {

        string[] instante;
        string[] horas;
        string[] minutos;
        string[] segundos;
        string[] termopar1;
        string[] termopar2;
        string[] lm35;

        int[] horas_numeric;
        int[] minutos_numeric;
        int[] segundos_numeric;

        int numeroDeLinhas;
        decimal[] termopar1_numeric;
        decimal[] termopar2_numeric;
        decimal[] lm35_numeric;
        decimal[] mediaTermopares1e2_numeric;
        DateTime[] sensores_time;

        int numeroDeLinhas_10em10s;
        decimal[] termopar1_numeric_10em10s;
        decimal[] termopar2_numeric_10em10s;
        decimal[] lm35_numeric_10em10s;
        decimal[] mediaTermopares1e2_numeric_10em10s;
        DateTime[] sensores_time_10em10s;

        int numeroDeLinhas_1em1min;
        decimal[] termopar1_numeric_1em1min;
        decimal[] termopar2_numeric_1em1min;
        decimal[] lm35_numeric_1em1min;
        decimal[] mediaTermopares1e2_numeric_1em1min;
        DateTime[] sensores_time_1em1min;

        int numeroDeLinhas_2em2min;
        decimal[] termopar1_numeric_2em2min;
        decimal[] termopar2_numeric_2em2min;
        decimal[] lm35_numeric_2em2min;
        decimal[] mediaTermopares1e2_numeric_2em2min;
        DateTime[] sensores_time_2em2min;

        int numeroDeLinhas_5em5min;
        decimal[] termopar1_numeric_5em5min;
        decimal[] termopar2_numeric_5em5min;
        decimal[] lm35_numeric_5em5min;
        decimal[] mediaTermopares1e2_numeric_5em5min;
        DateTime[] sensores_time_5em5min;

        int numeroDeLinhas_10em10min;
        decimal[] termopar1_numeric_10em10min;
        decimal[] termopar2_numeric_10em10min;
        decimal[] lm35_numeric_10em10min;
        decimal[] mediaTermopares1e2_numeric_10em10min;
        DateTime[] sensores_time_10em10min;




        public Form1()
        {
            InitializeComponent();
        }

        //Botão "Gerar relatório"
        private void button1_Click(object sender, EventArgs e)
        {
            /*--------APENAS CONTA O NUMERO DE LINHAS DO ARQUIVO---------*/
            StreamReader reader = new StreamReader("ARQUIVO.txt");
            string line = "";
            numeroDeLinhas = 0;
            while ((line = reader.ReadLine()) != null)
            {
                numeroDeLinhas++;
            }
            reader.Close();
            /*-----------------------------------------------------------*/
            Console.WriteLine("Numero de linhas: " + numeroDeLinhas.ToString());

            instante = new string[numeroDeLinhas];
            horas = new string[numeroDeLinhas];
            minutos = new string[numeroDeLinhas];
            segundos = new string[numeroDeLinhas];
            termopar1 = new string[numeroDeLinhas];
            termopar2 = new string[numeroDeLinhas];
            lm35 = new string[numeroDeLinhas];



            horas_numeric = new int[numeroDeLinhas];
            minutos_numeric = new int[numeroDeLinhas];
            segundos_numeric = new int[numeroDeLinhas];

            termopar1_numeric = new decimal[numeroDeLinhas];
            termopar2_numeric = new decimal[numeroDeLinhas];
            lm35_numeric = new decimal[numeroDeLinhas];
            mediaTermopares1e2_numeric = new decimal[numeroDeLinhas];
            sensores_time = new DateTime[numeroDeLinhas];

            numeroDeLinhas_10em10s =  numeroDeLinhas / 10 ;
            termopar1_numeric_10em10s = new decimal[numeroDeLinhas_10em10s];
            termopar2_numeric_10em10s = new decimal[numeroDeLinhas_10em10s];
            lm35_numeric_10em10s = new decimal[numeroDeLinhas_10em10s];
            mediaTermopares1e2_numeric_10em10s = new decimal[numeroDeLinhas_10em10s];
            sensores_time_10em10s = new DateTime[numeroDeLinhas_10em10s];

            numeroDeLinhas_1em1min =  numeroDeLinhas / 60 ;
            termopar1_numeric_1em1min = new decimal[numeroDeLinhas_1em1min];
            termopar2_numeric_1em1min = new decimal[numeroDeLinhas_1em1min];
            lm35_numeric_1em1min = new decimal[numeroDeLinhas_1em1min];
            mediaTermopares1e2_numeric_1em1min = new decimal[numeroDeLinhas_1em1min];
            sensores_time_1em1min = new DateTime[numeroDeLinhas_1em1min];

            numeroDeLinhas_2em2min =  numeroDeLinhas / 120 ;
            termopar1_numeric_2em2min = new decimal[numeroDeLinhas_2em2min];
            termopar2_numeric_2em2min = new decimal[numeroDeLinhas_2em2min];
            lm35_numeric_2em2min = new decimal[numeroDeLinhas_2em2min];
            mediaTermopares1e2_numeric_2em2min = new decimal[numeroDeLinhas_2em2min];
            sensores_time_2em2min = new DateTime[numeroDeLinhas_2em2min];

            numeroDeLinhas_5em5min = numeroDeLinhas / 300;
            termopar1_numeric_5em5min = new decimal[numeroDeLinhas_5em5min];
            termopar2_numeric_5em5min = new decimal[numeroDeLinhas_5em5min];
            lm35_numeric_5em5min = new decimal[numeroDeLinhas_5em5min];
            mediaTermopares1e2_numeric_5em5min = new decimal[numeroDeLinhas_5em5min];
            sensores_time_5em5min = new DateTime[numeroDeLinhas_5em5min];

            numeroDeLinhas_10em10min =  numeroDeLinhas / 600;
            termopar1_numeric_10em10min = new decimal[numeroDeLinhas_10em10min];
            termopar2_numeric_10em10min = new decimal[numeroDeLinhas_10em10min];
            lm35_numeric_10em10min = new decimal[numeroDeLinhas_10em10min];
            mediaTermopares1e2_numeric_10em10min = new decimal[numeroDeLinhas_10em10min];
            sensores_time_10em10min = new DateTime[numeroDeLinhas_10em10min];

            //inicializa arrays
            for (int i = 0; i < numeroDeLinhas; i++){
                instante[i] = ""; horas[i] = ""; minutos[i] = ""; segundos[i] = ""; termopar1[i] = ""; termopar2[i] = ""; lm35[i] = "";
                horas_numeric[i] = 0; minutos_numeric[i] = 0; segundos_numeric[i] = 0;
                termopar1_numeric[i] = 0M; termopar2_numeric[i] = 0M; lm35_numeric[i] = 0M;
                mediaTermopares1e2_numeric[i] = 0M;
            }
            for(int i=0; i<numeroDeLinhas_10em10s; i++){
                termopar1_numeric_10em10s[i] = 0M; termopar2_numeric_10em10s[i] = 0M; lm35_numeric_10em10s[i] = 0M; mediaTermopares1e2_numeric_10em10s[i] = 0M;
            }
            for(int i=0; i<numeroDeLinhas_1em1min; i++){
                termopar1_numeric_1em1min[i] = 0M; termopar2_numeric_1em1min[i] = 0M; lm35_numeric_1em1min[i] = 0M; mediaTermopares1e2_numeric_1em1min[i] = 0M;
            }
            for (int i = 0; i < numeroDeLinhas_2em2min; i++){
                termopar1_numeric_2em2min[i] = 0M; termopar2_numeric_2em2min[i] = 0M; lm35_numeric_2em2min[i] = 0M; mediaTermopares1e2_numeric_2em2min[i] = 0M;
            }
            for (int i = 0; i < numeroDeLinhas_5em5min; i++){
                termopar1_numeric_5em5min[i] = 0M; termopar2_numeric_5em5min[i] = 0M; lm35_numeric_5em5min[i] = 0M; mediaTermopares1e2_numeric_5em5min[i] = 0M;
            }
            for (int i = 0; i < numeroDeLinhas_10em10min; i++){
                termopar1_numeric_10em10min[i] = 0M; termopar2_numeric_10em10min[i] = 0M; lm35_numeric_10em10min[i] = 0M; mediaTermopares1e2_numeric_10em10min[i] = 0M;
            }


            reader = new StreamReader("ARQUIVO.txt");
            line = "";
            string charAux = "";
            int contador = 0;
            string  auxInstante = "", auxTermopar1 = "", auxTermopar2 = "", auxLM35 = "";
            int number_of_x = 0;
            int posicaoDoCaracter = 0;

            //o while a seguir será executado cada vez que uma nova linha for lida e copiada para 
            //a variável line. Portanto, o código dentro desse loop poderá processar cada linha
            //do arquivo de texto até a última linha
            while ((line = reader.ReadLine()) != null)
            {
                //O que deverá ser feito a cada iteração deste loop while:
                // -> copiar a hora para variavel temporaria auxHoras
                // -> copiar o minuto para variavel temporaria auxMinutos
                // -> copiar o segundo para variavel temporaria auxSegundos
                // -> copiar a temperatura do primeiro termopar para a variavel temporaria auxTermopar1
                // -> copiar a temperatura do segundo termopar para a variavel temporaria auxTermopar2
                // -> copiar a temperatura ambiente (LM35) para a variavel temporaria auxLM35
                //EM SEGUIDA:
                // -> transferir auxHoras para o array horas[] na próxima posição vazia
                // -> transferir auxMinutos para o array minutos[] na próxima posição vazia
                // -> transferir auxSegundos para o array segundos[] na próxima posição vazia
                // -> transferir auxTermopar1 para o array termopar1[] na próxima posição vazia
                // -> transferir auxTermopar2 para o array termopar2[] na próxima posição vazia
                // -> transferir auxLM35 para o array lm35[] na próxima posição vazia
                //FAZENDO ISSO QUE FOI DESCRITO ACIMA, AO TERMINAR O LOOP WHILE, ESSES ARRAYS
                // horas[], minutos[], segundos[], termopar1[], termopar2[], lm35[], TERÃO
                // TODOS O MESMO NÚMERO DE ELEMENTOS, E ESSE NÚMERO SERÁ
                // IGUAL AO NÚMERO DE LINHAS DO ARQUIVO QUE FOI LIDO NO LOOP WHILE. ALÉM DISSO,
                // OS ELEMENTOS DE MESMO ÍNDICE DESSES ARRAYS CORRESPONDERÃO A UMA ÚNICA LINHA
                // DO ARQUIVO, E PODERÃO, ASSIM, SER PROCESSADOS EM CONJUNTO PARA DESENHAR UM 
                // GRÁFICO OU FAZER QUALQUER OUTRA ANÁLISE DA FORMA COMO SE QUEIRA.

                int numeroDeCaracteres = line.Length;// PEGA O NÚMERO DE CARACTERES DA STRING line
                //O LOOP FOR A SEGUIR É EXECUTADO PARA CADA CARACTER DA STRING line.
                //DURANTE A EXECUÇÃO DESSE LOOP, O ÍNDICE posicaoDoCaracter REPRESENTA O CARACTERE DA VEZ
                //DE MODO QUE, USANDO O ÍNDICE posicaoDoCaracter NESSE LOOP FOR, É POSSÍVEL LER 
                //TODOS OS CARACTERES DA STRING LINE DESDE O PRIMEIRO ATÉ O ÚLTIMO.
                number_of_x = 0; //ZERA ESSA VARIÁVEL PARA QUE SEJA USADA NO LOOP FOR A SEGUIR
                for (posicaoDoCaracter = 0; posicaoDoCaracter < numeroDeCaracteres; posicaoDoCaracter++){
                    //o que deverá ser feito a cada iteração deste loop for:
                    //LER CARACTERES DE INDICE posicaoDoCaractere E A CADA 'x' LIDO, INCREMENTAR
                    //UMA VARIÁVEL QUE CONTA O NÚMERO DE CARACTERES 'x' LIDOS. ALÉM DISSO, TER EM
                    //MENTE QUE O NÚMERO DE CARACTERES 'x' LIDOS ESTÁ RELACIONADO COM QUAL INFORMAÇÃO
                    //SERÁ LIDA A SEGUIR, COM BASE NA FORMA COMO O ARQUIVO.txt  ESTÁ CONSTRUÍDO.
                    //POR EXEMPLO, A SEGUIR ESTÁ UMA LINHA DO ARQUIVO.txt:
                    // x15p36p01x        x20.25x        x24.75x        x18.00x
                    //PERCEBA QUE APÓS A LEITURA DO PRIMEIRO 'x', OS PRÓXIMOS CARACTERES LIDOS ATÉ QUE O
                    //SEGUNDO 'x' SEJA LIDO CORRESPONDEM AOS CARACTERES DE UMA STRING QUE REPRESENTA O INSTANTE.
                    //DA MESMA FORMA, APÓS A LEITURA DO TERCEIRO 'x', OS PRÓXIMOS CARACTERES LIDOS ATÉ QUE
                    //O QUARTO 'x' SEJA LIDO CORRESPONDEM AOS CARACTERES DE UMA STRING QUE REPRESENTA A 
                    //TERMOPAR1, ETC.
                    //SABENDO ISSO, É PRECISO LER CARACTERE A CARACTERE DA STRING line E IR CAPTANDO
                    //AS INFORMAÇÕES DESEJADAS, CARACTERE A CARACTERE, TRANSFORMAR ESSES CARACTERES EM 
                    //STRINGS, E SALVAR A STRING NA CORRESPONDENTE VARIÁVEL AUXILIAR.
                    //LEMBRAR QUE NO MOMENTO DA LEITURA DO INSTANTE, ESTE ESTÁ DIVIDIDO EM HORA, MINUTO E 
                    //SEGUNDO DA SEGUINTE FORMA: ATÉ O PRIMEIRO CARACTERE 'p' ESTAMOS LENDO HORA, DEPOIS, ATÉ
                    //O SEGUNDO CARACTERE 'p' ESTAMOS LENDO MINUTO, DEPOIS, ATÉ O PRÓXIMO CARACTERE 'x', ESTAMOS 
                    //LENDO SEGUNDO.

                    charAux = line[posicaoDoCaracter].ToString(); //LÊ O CARACTER DA VEZ
               
                    if ((number_of_x == 1) && (!charAux.Equals("x"))){
                        auxInstante = auxInstante + charAux;
                    }
                    if ((number_of_x == 3) && (!charAux.Equals("x"))){ 
                        auxTermopar1 = auxTermopar1 + charAux;
                    }
                    if ((number_of_x == 5) && (!charAux.Equals("x"))){
                        auxTermopar2 = auxTermopar2 + charAux;
                    }
                    if ((number_of_x == 7) && (!charAux.Equals("x"))){
                        auxLM35 = auxLM35 + charAux;
                    }
                    if (charAux.Equals("x")){
                        number_of_x++;
                    }
                }

                instante[contador] = auxInstante;
                auxInstante = "";
                termopar1[contador] = auxTermopar1;
                auxTermopar1 = "";
                termopar2[contador] = auxTermopar2;
                auxTermopar2 = "";
                lm35[contador] = auxLM35;
                auxLM35 = "";

                contador++;

            }
            reader.Close();


            //Verificando se há leitura "NAN" nos registros do termopar1:
            int numeroDeNAN_termopar1 = 0;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (String.Equals(termopar1[i].ToLower(), "nan")){
                    numeroDeNAN_termopar1++;
                }
            }
            string houveRegistroNAN_termopar1 = "Não";
            if (numeroDeNAN_termopar1 > 0)
                houveRegistroNAN_termopar1 = "Sim";
            //Agora, na sequência, se houve leitura "NAN", substituir cada uma dessas 
            //leituras "not a number" por "0"
            if(numeroDeNAN_termopar1 > 0){
                for(int i = 0; i<numeroDeLinhas; i++){
                    if (String.Equals(termopar1[i].ToLower(), "nan"))
                        termopar1[i] = "0";
                }
            }


            //Verificando se há leitura "NAN" nos registros do termopar2:
            int numeroDeNAN_termopar2 = 0;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (String.Equals(termopar2[i].ToLower(), "nan")){
                    numeroDeNAN_termopar2++;
                }
            }
            string houveRegistroNAN_termopar2 = "Não";
            if (numeroDeNAN_termopar2 > 0)
                houveRegistroNAN_termopar2 = "Sim";
            //Agora, na sequência, se houve leitura "NAN", substituir cada uma dessas 
            //leituras "not a number" por "0"
            if (numeroDeNAN_termopar2 > 0){
                for (int i = 0; i < numeroDeLinhas; i++){
                    if (String.Equals(termopar2[i].ToLower(), "nan"))
                        termopar2[i] = "0";
                }
            }





            //Separando cada elemento de instante[n] em hora, minuto e segundo
            for (int i=0; i<numeroDeLinhas; i++){
                var partes = instante[i].Split('p');
                horas[i] = partes[0];
                minutos[i] = partes[1];
                segundos[i] = partes[2];
            }

            //convertendo as strings dos arrays horas[], minutos[] e segundos[] em valores inteiros e armazenando 
            //esses valores nos arrays de inteiros horas_numeric[], minutos_numeric[] e segundos_numeric[]
            for (int i = 0; i < numeroDeLinhas; ++i){
                horas_numeric[i] = int.Parse(horas[i]);
                minutos_numeric[i] = int.Parse(minutos[i]);
                segundos_numeric[i] = int.Parse(segundos[i]);
            }




            //considerando o primeiro instante registrado e o último instante registrado, 
            //calcular o número de registros esperado com base numa variação de 1 em 1 segundo
            Int32 year_generic = 2000, month_generic = 1, day_generic = 1;
            DateTime time_inicial = new DateTime(year_generic, month_generic, day_generic, horas_numeric[0], minutos_numeric[0], segundos_numeric[0]);
            DateTime time_final = new DateTime(year_generic, month_generic, day_generic, horas_numeric[numeroDeLinhas-1], minutos_numeric[numeroDeLinhas-1], segundos_numeric[numeroDeLinhas-1]);
            double numeroDeRegistrosEsperado = (time_final - time_inicial).TotalSeconds + 1;


            //convertendo as strings do array termopar1[] em valores decimal e armazenando 
            //esses valores no array de decimal termopar1_numeric[]
            //OBS: foi necessário passar o parâmetro (new CultureInfo("en-US")) pois sem ele
            //o método parse convertia a string "20.25" em um decimal de valor 2025 (sem o ponto decimal).
            //Usando o parâmetro (new CultureInfo("en-US")) esse problema foi resolvido, apesar de que, após 
            //a conversão, o console mostra que a string "20.25" foi convertida no decimal 20,25 (com a vírgula)
            //ao inves do ponto. 
            for (int i = 0; i < numeroDeLinhas; ++i){
                termopar1_numeric[i] = decimal.Parse(termopar1[i], new CultureInfo("en-US"));
                termopar2_numeric[i] = decimal.Parse(termopar2[i], new CultureInfo("en-US"));
                lm35_numeric[i] = decimal.Parse(lm35[i], new CultureInfo("en-US"));
            }

            //Calculando a média dos valores dos termopares 1 e 2 e armazenando em um novo array
            for (int i = 0; i < numeroDeLinhas; i++){
                mediaTermopares1e2_numeric[i] = Math.Round((termopar1_numeric[i] + termopar2_numeric[i]) / 2 , 2);
            }

            //verificando qual foi o maior valor de temperatura registrado no termopar1 e, na sequência, 
            //verificando quantas vezes esse valor foi observado
            decimal maiorValorTermopar1 = 0m;
            for (int i = 0; i < numeroDeLinhas; i++) {
                if (termopar1_numeric[i] > maiorValorTermopar1)
                    maiorValorTermopar1 = termopar1_numeric[i];
            }
            int nVezes_maiorValorTermopar1 = 0;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (termopar1_numeric[i] == maiorValorTermopar1)
                    nVezes_maiorValorTermopar1++;
            }


            //verificando qual foi o maior valor de temperatura registrado no termopar2 e, na sequência, 
            //verificando quantas vezes esse valor foi observado
            decimal maiorValorTermopar2 = 0m;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (termopar2_numeric[i] > maiorValorTermopar2)
                    maiorValorTermopar2 = termopar2_numeric[i];
            }
            int nVezes_maiorValorTermopar2 = 0;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (termopar2_numeric[i] == maiorValorTermopar2)
                    nVezes_maiorValorTermopar2++;
            }

            //verificando qual foi o maior valor de temperatura registrado no lm35 e, na sequência, 
            //verificando quantas vezes esse valor foi observado
            decimal maiorValorLm35 = 0m;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (lm35_numeric[i] > maiorValorLm35)
                    maiorValorLm35 = lm35_numeric[i];
            }
            int nVezes_maiorValorLm35 = 0;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (lm35_numeric[i] == maiorValorLm35)
                    nVezes_maiorValorLm35++;
            }


            //verificando qual foi o menor valor de temperatura registrado no termopar1 e, na sequência, 
            //verificando quantas vezes esse valor foi observado
            decimal menorValorTermopar1 = 1000m;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (termopar1_numeric[i] < menorValorTermopar1)
                    menorValorTermopar1 = termopar1_numeric[i];         
            }
            int nVezes_menorValorTermopar1 = 0;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (termopar1_numeric[i] == menorValorTermopar1)
                    nVezes_menorValorTermopar1++;
            }

            //verificando qual foi o menor valor de temperatura registrado no termopar2 e, na sequência, 
            //verificando quantas vezes esse valor foi observado
            decimal menorValorTermopar2 = 1000m;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (termopar2_numeric[i] < menorValorTermopar2)
                    menorValorTermopar2 = termopar2_numeric[i];
            }
            int nVezes_menorValorTermopar2 = 0;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (termopar2_numeric[i] == menorValorTermopar2)
                    nVezes_menorValorTermopar2++;
            }

            //verificando qual foi o menor valor de temperatura registrado no lm35 e, na sequência, 
            //verificando quantas vezes esse valor foi observado
            decimal menorValorLm35 = 1000m;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (lm35_numeric[i] < menorValorLm35)
                    menorValorLm35 = lm35_numeric[i];
            }
            int nVezes_menorValorLm35 = 0;
            for (int i = 0; i < numeroDeLinhas; i++){
                if (lm35_numeric[i] == menorValorLm35)
                    nVezes_menorValorLm35++;
            }



            //calculando a maior variação de temperatura observada em 1s no termopar1
            decimal maiorVariacaoEm1s_termopar1 = 0m; 
            for (int i = 0; i < numeroDeLinhas - 1; i++){
                if ((Math.Abs(termopar1_numeric[i + 1] - termopar1_numeric[i])) > maiorVariacaoEm1s_termopar1)
                    maiorVariacaoEm1s_termopar1 = Math.Abs(termopar1_numeric[i + 1] - termopar1_numeric[i]);
            }


            //calculando a maior variação de temperatura observada em 1s no termopar2
            decimal maiorVariacaoEm1s_termopar2 = 0m;
            for (int i = 0; i < numeroDeLinhas - 1; i++){
                if ((Math.Abs(termopar2_numeric[i + 1] - termopar2_numeric[i])) > maiorVariacaoEm1s_termopar2)
                    maiorVariacaoEm1s_termopar2 = Math.Abs(termopar2_numeric[i + 1] - termopar2_numeric[i]);
            }


            //calculando a maior variação de temperatura observada em 1s no lm35
            decimal maiorVariacaoEm1s_lm35 = 0m;
            for (int i = 0; i < numeroDeLinhas - 1; i++){
                if ((Math.Abs(lm35_numeric[i + 1] - lm35_numeric[i])) > maiorVariacaoEm1s_lm35)
                    maiorVariacaoEm1s_lm35 = Math.Abs(lm35_numeric[i + 1] - lm35_numeric[i]);
            }

            //Calculando a maior diferença de temperatura observada nos termopares
            decimal maiorDiferencaTermopares1e2 = 0m;
            for(int i=0; i<numeroDeLinhas; i++){
                if (Math.Abs(termopar1_numeric[i] - termopar2_numeric[i]) > maiorDiferencaTermopares1e2)
                    maiorDiferencaTermopares1e2 = Math.Abs(termopar1_numeric[i] - termopar2_numeric[i]);
            }


            /*
             * indice i:                            0      1      2      3      4      5      6      7      8      9      10     11     12
             * ex. de termopar1_numeric:          20.00  20.25  20.50  20.75  21.00  21.25  21.50   21.75  22.00  22.25  22.50  22.75  23.00                       
             * ex. de termopar1_numeric_10em10s:  20.00  22.50
             * 
             * Se os dados acima foram obtidos a partir de um arquivo gerado pelo circuito dos sensores, então podemos concluir que
             * esse arquivo tem 13 linhas. Com isso, podemos concluir também que o array termopar1_numeric_10em10s tem 
             * numeroDeLinhas_10em10s = 13/10 = 1. Mas essa variável inteira numeroDeLinhas_10em10s é usada geralmente como 
             * o índice da matriz numeroDeLinhas_10em10s, e índice de valor 1 representa o segundo elemento (pois o primeiro tem 
             * índice 0).
             * 
             */


            //Construindo arrays menores, com dados obtidos de 10 em 10 s
            for (int i = 0; i < numeroDeLinhas_10em10s; i++){
                termopar1_numeric_10em10s[i] = termopar1_numeric[10 * i];
                termopar2_numeric_10em10s[i] = termopar2_numeric[10 * i];
                lm35_numeric_10em10s[i] = lm35_numeric[10 * i];
                mediaTermopares1e2_numeric_10em10s[i] = mediaTermopares1e2_numeric[10 * i];
            }
            //Construindo arrays menores, com dados obtidos de 1 em 1 min
            for (int i=0; i<numeroDeLinhas_1em1min; i++){
                termopar1_numeric_1em1min[i] = termopar1_numeric[60 * i];
                termopar2_numeric_1em1min[i] = termopar2_numeric[60 * i];
                lm35_numeric_1em1min[i] = lm35_numeric[60 * i];
                mediaTermopares1e2_numeric_1em1min[i] = mediaTermopares1e2_numeric[60 * i]; 
            }
            //Construindo arrays menores, com dados obtidos de 2 em 2 min
            for (int i = 0; i < numeroDeLinhas_2em2min; i++){
                termopar1_numeric_2em2min[i] = termopar1_numeric[120 * i];
                termopar2_numeric_2em2min[i] = termopar2_numeric[120 * i];
                lm35_numeric_2em2min[i] = lm35_numeric[120 * i];
                mediaTermopares1e2_numeric_2em2min[i] = mediaTermopares1e2_numeric[120 * i];
            }
            //Construindo arrays menores, com dados obtidos de 5 em 5 min
            for (int i = 0; i < numeroDeLinhas_5em5min; i++){
                termopar1_numeric_5em5min[i] = termopar1_numeric[300 * i];
                termopar2_numeric_5em5min[i] = termopar2_numeric[300 * i];
                lm35_numeric_5em5min[i] = lm35_numeric[300 * i];
                mediaTermopares1e2_numeric_5em5min[i] = mediaTermopares1e2_numeric[300 * i];
            }
            //Construindo arrays menores, com dados obtidos de 10 em 10 min
            for (int i = 0; i < numeroDeLinhas_10em10min; i++){
                termopar1_numeric_10em10min[i] = termopar1_numeric[600 * i];
                termopar2_numeric_10em10min[i] = termopar2_numeric[600 * i];
                lm35_numeric_10em10min[i] = lm35_numeric[600 * i];
                mediaTermopares1e2_numeric_10em10min[i] = mediaTermopares1e2_numeric[600 * i];
            }

            //criando as arrays sensores_time_... com os dados completos da tabela ARQUIVO.txt
            //ano, mes, dia, hora, minuto, segundo... ignora-se ano, mes e dia. Não importa
            DateTime sensores_time_inicio = new DateTime(2000, 1, 1, horas_numeric[0], minutos_numeric[0], segundos_numeric[0]);
            DateTime sensores_time_aux = sensores_time_inicio;
            for (int i = 0; i < numeroDeLinhas; i++){
                sensores_time[i] = sensores_time_aux;
                sensores_time_aux = sensores_time_aux.AddSeconds(1);
            }
            sensores_time_aux = sensores_time_inicio;
            for (int i = 0; i < numeroDeLinhas_10em10s; i++){
                sensores_time_10em10s[i] = sensores_time_aux;
                sensores_time_aux = sensores_time_aux.AddSeconds(10);
            }
            sensores_time_aux = sensores_time_inicio;
            for(int i=0; i<numeroDeLinhas_1em1min; i++){
                sensores_time_1em1min[i] = sensores_time_aux;
                sensores_time_aux = sensores_time_aux.AddSeconds(60);
            }
            sensores_time_aux = sensores_time_inicio;
            for(int i=0; i<numeroDeLinhas_2em2min; i++){
                sensores_time_2em2min[i] = sensores_time_aux;
                sensores_time_aux = sensores_time_aux.AddSeconds(120);
            }
            sensores_time_aux = sensores_time_inicio;
            for (int i = 0; i < numeroDeLinhas_5em5min; i++){
                sensores_time_5em5min[i] = sensores_time_aux;
                sensores_time_aux = sensores_time_aux.AddSeconds(300);
            }
            sensores_time_aux = sensores_time_inicio;
            for (int i = 0; i < numeroDeLinhas_10em10min; i++){
                sensores_time_10em10min[i] = sensores_time_aux;
                sensores_time_aux = sensores_time_aux.AddSeconds(600);
            }






            textBox1.Text = "                                                                " + "Relatório" + "\r\n\r\n" ;
            textBox1.AppendText("Número de linhas do arquivo .txt:  " + numeroDeLinhas.ToString() + "\r\n\r\n");
 
            textBox1.AppendText("                                         " + "Primeira coluna de dados (hora:min:seg):" + "\r\n\r\n");
            textBox1.AppendText("- Primeiro registro: " + instante[0] + "\r\n");
            textBox1.AppendText("- Último registro: " + instante[numeroDeLinhas - 1] + "\r\n");
            textBox1.AppendText("- Número de registros esperado com base numa variação de 1 em 1 segundo: " + numeroDeRegistrosEsperado + "\r\n");
            textBox1.AppendText("- Número de registros obtido: " + numeroDeLinhas + "\r\n");

            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("                                         " + "Segunda coluna de dados (termopar 1):" + "\r\n\r\n");
            textBox1.AppendText("- Primeiro registro: " + termopar1[0] + "\r\n");
            textBox1.AppendText("- Último registro: " + termopar1[numeroDeLinhas - 1] + "\r\n");
            textBox1.AppendText("- Número de registros obtido: " + numeroDeLinhas + "\r\n");
            textBox1.AppendText("- Houve registro 'NAN'? " + houveRegistroNAN_termopar1 + "\r\n");
            textBox1.AppendText("- Número de registros 'NAN': " + numeroDeNAN_termopar1 + "\r\n");
            textBox1.AppendText("- Maior valor registrado: " + maiorValorTermopar1 + "\r\n");
            textBox1.AppendText("- Número de vezes que o maior valor foi registrado: " + nVezes_maiorValorTermopar1 + "\r\n");
            textBox1.AppendText("- Instantes de maior valor registrado: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Menor valor registrado: " + menorValorTermopar1 + "\r\n");
            textBox1.AppendText("- Número de vezes que o menor valor foi registrado: " + nVezes_menorValorTermopar1 + "\r\n");
            textBox1.AppendText("- Instantes de menor valor registrado: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Maior variação de temperatura observada em 1s: " + maiorVariacaoEm1s_termopar1 + "\r\n");
            textBox1.AppendText("- Instantes de maior variação de observada em 1s: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Média dos registros: " + Math.Round(System.Linq.Enumerable.Average(termopar1_numeric), 2) + "\r\n");
            textBox1.AppendText("- Mediana dos registros: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Desvio padrão: (implementar se for útil)" + "\r\n");

            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("                                         " + "Terceira coluna de dados (termopar 2):" + "\r\n\r\n");
            textBox1.AppendText("- Primeiro registro: " + termopar2[0] + "\r\n");
            textBox1.AppendText("- Último registro: " + termopar2[numeroDeLinhas - 1] + "\r\n");
            textBox1.AppendText("- Número de registros obtido: " + numeroDeLinhas + "\r\n");
            textBox1.AppendText("- Houve registro 'NAN'? " + houveRegistroNAN_termopar2 + "\r\n");
            textBox1.AppendText("- Número de registros 'NAN': " + numeroDeNAN_termopar2 + "\r\n");
            textBox1.AppendText("- Maior valor registrado: " + maiorValorTermopar2 + "\r\n");
            textBox1.AppendText("- Número de vezes que o maior valor foi registrado: " + nVezes_maiorValorTermopar2 + "\r\n");
            textBox1.AppendText("- Instantes de maior valor registrado: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Menor valor registrado: " + menorValorTermopar2 + "\r\n");
            textBox1.AppendText("- Número de vezes que o menor valor foi registrado: " + nVezes_menorValorTermopar2 + "\r\n");
            textBox1.AppendText("- Instantes de menor valor registrado: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Maior variação de temperatura observada em 1s: " + maiorVariacaoEm1s_termopar2 + "\r\n");
            textBox1.AppendText("- Instantes de maior variação de observada em 1s: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Média dos registros: " + Math.Round(System.Linq.Enumerable.Average(termopar2_numeric), 2) + "\r\n");
            textBox1.AppendText("- Mediana dos registros: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Desvio padrão: (implementar se for útil)" + "\r\n");

            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("                                         " + "Quarta coluna de dados (LM35):" + "\r\n\r\n");
            textBox1.AppendText("- Primeiro registro: " + lm35_numeric[0] + "\r\n");
            textBox1.AppendText("- Último registro: " + lm35_numeric[numeroDeLinhas - 1] + "\r\n");
            textBox1.AppendText("- Número de registros obtido: " + numeroDeLinhas + "\r\n");
            textBox1.AppendText("- Maior valor registrado: " + maiorValorLm35 + "\r\n");
            textBox1.AppendText("- Número de vezes que o maior valor foi registrado: " + nVezes_maiorValorLm35 + "\r\n");
            textBox1.AppendText("- Instantes de maior valor registrado: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Menor valor registrado: " + menorValorLm35 + "\r\n");
            textBox1.AppendText("- Número de vezes que o menor valor foi registrado: " + nVezes_menorValorLm35+ "\r\n");
            textBox1.AppendText("- Instantes de menor valor registrado: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Maior variação de temperatura observada em 1s: " + maiorVariacaoEm1s_lm35 + "\r\n");
            textBox1.AppendText("- Instantes de maior variação de observada em 1s: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Média dos registros: " + Math.Round(System.Linq.Enumerable.Average(lm35_numeric), 2) + "\r\n");
            textBox1.AppendText("- Mediana dos registros: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Desvio padrão: (implementar se for útil)" + "\r\n");

            textBox1.AppendText("\r\n\r\n");

            textBox1.AppendText("                                         " + "Dados adicionais:" + "\r\n\r\n");
            textBox1.AppendText("- Maior diferença de temperatura observada nos termopares: " + maiorDiferencaTermopares1e2 + "\r\n");
            textBox1.AppendText("- Instantes dessa maior diferença: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Valores do termopar 1 nesses instantes: (implementar se for útil)" + "\r\n");
            textBox1.AppendText("- Valores do termopar 2 nesses instantes: (implementar se for útil)" + "\r\n");



            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox5.Enabled = true;

            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            button2.Enabled = true;
            button6.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown1.Value = 2;
           

        }



        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked){
                if (checkBox2.Checked)
                    checkBox2.Checked = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            if (!checkBox2.Checked)
                checkBox1.Checked = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked){
                if(checkBox1.Checked)
                    checkBox1.Checked = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            if (!checkBox1.Checked)
                checkBox2.Checked = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //Botão "Plotar"
        private void button6_Click(object sender, EventArgs e) 
        {
            //mensagem de erro caso o usuário não escolha nenhum sensor
            if( String.Equals(comboBox1.Text, "") && String.Equals(comboBox3.Text, "") && 
                String.Equals(comboBox4.Text, "") && String.Equals(comboBox5.Text, "")){
                MessageBox.Show("Escolha ao menos um sensor!", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else{

                //mensagem de erro caso o usuário não escolha a amostragem
                if(String.Equals(comboBox2.Text, "")){
                    MessageBox.Show("Escolha a amostragem!", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else{
                    //calculando o número de sensores diferentes que foram selecionados nas combobox de sensores e
                    //colocando esses sensores diferentes num array de tamanho adequado
                    String[] sensoresEscolhidos_aux = new string[4];
                    sensoresEscolhidos_aux[0] = comboBox1.Text;
                    sensoresEscolhidos_aux[1] = comboBox3.Text;
                    sensoresEscolhidos_aux[2] = comboBox4.Text;
                    sensoresEscolhidos_aux[3] = comboBox5.Text;
                    String[] sensoresEscolhidos = new string[4];
                    sensoresEscolhidos = sensoresEscolhidos_aux.Distinct().ToArray();
                    String[] aux_except = new string[1];
                    aux_except[0] = "";
                    sensoresEscolhidos = sensoresEscolhidos.Except(aux_except).ToArray();
                    int nSensoresEscolhidos = sensoresEscolhidos.Length;

                    String amostragem = comboBox2.Text;

                    //Se o usuário escolheu "Usar dados completos"... 
                    //Obs: "Usar dados completos" significa que o usuário quer usar todas as linhas
                    //da tabela do ARQUIVO.txt para plotar o gráfico (do primeiro instante ao último instante)
                    if (checkBox1.Checked){

                        Form2 formularioGrafico1 = new Form2();
                        formularioGrafico1.Show();

                        //Se o usuário escolheu plotar apenas 1 sensor...
                        if(nSensoresEscolhidos == 1){
                            if (String.Equals(amostragem, "A cada segundo")){
                                if (String.Equals(sensoresEscolhidos[0], "Termopar 1"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0],(int)this.numericUpDown1.Value, numeroDeLinhas, termopar1_numeric, sensores_time);
                                else if (String.Equals(sensoresEscolhidos[0], "Termopar 2"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas, termopar2_numeric, sensores_time);
                                else if (String.Equals(sensoresEscolhidos[0], "Lm35"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas, lm35_numeric, sensores_time);
                                else if (String.Equals(sensoresEscolhidos[0], "Media dos termopares"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas, mediaTermopares1e2_numeric, sensores_time);
                            }
                            else if (String.Equals(amostragem, "A cada dez segundos")){
                                if (String.Equals(sensoresEscolhidos[0], "Termopar 1"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10s, termopar1_numeric_10em10s, sensores_time_10em10s);
                                else if (String.Equals(sensoresEscolhidos[0], "Termopar 2"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10s, termopar2_numeric_10em10s, sensores_time_10em10s);
                                else if (String.Equals(sensoresEscolhidos[0], "Lm35"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10s, lm35_numeric_10em10s, sensores_time_10em10s);
                                else if (String.Equals(sensoresEscolhidos[0], "Media dos termopares"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10s, mediaTermopares1e2_numeric_10em10s, sensores_time_10em10s);
                            }
                            else if (String.Equals(amostragem, "A cada minuto")){
                                if (String.Equals(sensoresEscolhidos[0], "Termopar 1"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_1em1min, termopar1_numeric_1em1min, sensores_time_1em1min);
                                else if (String.Equals(sensoresEscolhidos[0], "Termopar 2"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_1em1min, termopar2_numeric_1em1min, sensores_time_1em1min);
                                else if (String.Equals(sensoresEscolhidos[0], "Lm35"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_1em1min, lm35_numeric_1em1min, sensores_time_1em1min);
                                else if (String.Equals(sensoresEscolhidos[0], "Media dos termopares"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_1em1min, mediaTermopares1e2_numeric_1em1min, sensores_time_1em1min);
                            }
                            else if (String.Equals(amostragem, "A cada dois minutos")){
                                if (String.Equals(sensoresEscolhidos[0], "Termopar 1"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_2em2min, termopar1_numeric_2em2min, sensores_time_2em2min);
                                else if (String.Equals(sensoresEscolhidos[0], "Termopar 2"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_2em2min, termopar2_numeric_2em2min, sensores_time_2em2min);
                                else if (String.Equals(sensoresEscolhidos[0], "Lm35"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_2em2min, lm35_numeric_2em2min, sensores_time_2em2min);
                                else if (String.Equals(sensoresEscolhidos[0], "Media dos termopares"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_2em2min, mediaTermopares1e2_numeric_2em2min, sensores_time_2em2min);
                            }
                            else if (String.Equals(amostragem, "A cada cinco minutos")){
                                if (String.Equals(sensoresEscolhidos[0], "Termopar 1"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_5em5min, termopar1_numeric_5em5min, sensores_time_5em5min);
                                else if (String.Equals(sensoresEscolhidos[0], "Termopar 2"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_5em5min, termopar2_numeric_5em5min, sensores_time_5em5min);
                                else if (String.Equals(sensoresEscolhidos[0], "Lm35"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_5em5min, lm35_numeric_5em5min, sensores_time_5em5min);
                                else if (String.Equals(sensoresEscolhidos[0], "Media dos termopares"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_5em5min, mediaTermopares1e2_numeric_5em5min, sensores_time_5em5min);
                            }
                            else if (String.Equals(amostragem, "A cada dez minutos")){
                                if (String.Equals(sensoresEscolhidos[0], "Termopar 1"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10min, termopar1_numeric_10em10min, sensores_time_10em10min);
                                else if (String.Equals(sensoresEscolhidos[0], "Termopar 2"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10min, termopar2_numeric_10em10min, sensores_time_10em10min);
                                else if (String.Equals(sensoresEscolhidos[0], "Lm35"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10min, lm35_numeric_10em10min, sensores_time_10em10min);
                                else if (String.Equals(sensoresEscolhidos[0], "Media dos termopares"))
                                    formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10min, mediaTermopares1e2_numeric_10em10min, sensores_time_10em10min);
                            }
                        }
                        else if(nSensoresEscolhidos == 2){
                            if(String.Equals(amostragem, "A cada segundo")){

                                decimal[] y1, y2;
                                DateTime[] x1, x2;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric; y2 = termopar2_numeric;
                                x1 = sensores_time; x2 = sensores_time;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time;
                                    y1 = termopar1_numeric;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time;
                                    y1 = termopar2_numeric;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time;
                                    y1 = lm35_numeric;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time;
                                    y1 = mediaTermopares1e2_numeric;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time;
                                    y2 = termopar1_numeric;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time;
                                    y2 = termopar2_numeric;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time;
                                    y2 = lm35_numeric;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time;
                                    y2 = mediaTermopares1e2_numeric;
                                }


                                formularioGrafico1.plotarDoisGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], (int)this.numericUpDown1.Value, numeroDeLinhas,
                                    y1, x1, y2, x2);
                            }
                            else if (String.Equals(amostragem, "A cada dez segundos")){

                                decimal[] y1, y2;
                                DateTime[] x1, x2;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_10em10s; y2 = termopar2_numeric_10em10s;
                                x1 = sensores_time_10em10s; x2 = sensores_time_10em10s;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_10em10s;
                                    y1 = termopar1_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_10em10s;
                                    y1 = termopar2_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_10em10s;
                                    y1 = lm35_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_10em10s;
                                    y1 = mediaTermopares1e2_numeric_10em10s;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_10em10s;
                                    y2 = termopar1_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_10em10s;
                                    y2 = termopar2_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_10em10s;
                                    y2 = lm35_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_10em10s;
                                    y2 = mediaTermopares1e2_numeric_10em10s;
                                }


                                formularioGrafico1.plotarDoisGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10s,
                                    y1, x1, y2, x2);
                            }
                            else if (String.Equals(amostragem, "A cada minuto")){

                                decimal[] y1, y2;
                                DateTime[] x1, x2;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_1em1min; y2 = termopar2_numeric_1em1min;
                                x1 = sensores_time_1em1min; x2 = sensores_time_1em1min;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_1em1min;
                                    y1 = termopar1_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_1em1min;
                                    y1 = termopar2_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_1em1min;
                                    y1 = lm35_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_1em1min;
                                    y1 = mediaTermopares1e2_numeric_1em1min;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_1em1min;
                                    y2 = termopar1_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_1em1min;
                                    y2 = termopar2_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_1em1min;
                                    y2 = lm35_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_1em1min;
                                    y2 = mediaTermopares1e2_numeric_1em1min;
                                }


                                formularioGrafico1.plotarDoisGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], (int)this.numericUpDown1.Value, numeroDeLinhas_1em1min,
                                    y1, x1, y2, x2);
                            }
                            else if (String.Equals(amostragem, "A cada dois minutos")){

                                decimal[] y1, y2;
                                DateTime[] x1, x2;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_2em2min; y2 = termopar2_numeric_2em2min;
                                x1 = sensores_time_2em2min; x2 = sensores_time_2em2min;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_2em2min;
                                    y1 = termopar1_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_2em2min;
                                    y1 = termopar2_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_2em2min;
                                    y1 = lm35_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_2em2min;
                                    y1 = mediaTermopares1e2_numeric_2em2min;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_2em2min;
                                    y2 = termopar1_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_2em2min;
                                    y2 = termopar2_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_2em2min;
                                    y2 = lm35_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_2em2min;
                                    y2 = mediaTermopares1e2_numeric_2em2min;
                                }


                                formularioGrafico1.plotarDoisGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], (int)this.numericUpDown1.Value, numeroDeLinhas_2em2min,
                                    y1, x1, y2, x2);
                            }
                            else if (String.Equals(amostragem, "A cada cinco minutos")){

                                decimal[] y1, y2;
                                DateTime[] x1, x2;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_5em5min; y2 = termopar2_numeric_5em5min;
                                x1 = sensores_time_5em5min; x2 = sensores_time_5em5min;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_5em5min;
                                    y1 = termopar1_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_5em5min;
                                    y1 = termopar2_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_5em5min;
                                    y1 = lm35_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_5em5min;
                                    y1 = mediaTermopares1e2_numeric_5em5min;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_5em5min;
                                    y2 = termopar1_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_5em5min;
                                    y2 = termopar2_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_5em5min;
                                    y2 = lm35_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_5em5min;
                                    y2 = mediaTermopares1e2_numeric_5em5min;
                                }


                                formularioGrafico1.plotarDoisGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], (int)this.numericUpDown1.Value, numeroDeLinhas_5em5min,
                                    y1, x1, y2, x2);
                            }
                            else if (String.Equals(amostragem, "A cada dez minutos")){

                                decimal[] y1, y2;
                                DateTime[] x1, x2;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_10em10min; y2 = termopar2_numeric_10em10min;
                                x1 = sensores_time_10em10min; x2 = sensores_time_10em10min;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_10em10min;
                                    y1 = termopar1_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_10em10min;
                                    y1 = termopar2_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_10em10min;
                                    y1 = lm35_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_10em10min;
                                    y1 = mediaTermopares1e2_numeric_10em10min;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_10em10min;
                                    y2 = termopar1_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_10em10min;
                                    y2 = termopar2_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_10em10min;
                                    y2 = lm35_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_10em10min;
                                    y2 = mediaTermopares1e2_numeric_10em10min;
                                }


                                formularioGrafico1.plotarDoisGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10min,
                                    y1, x1, y2, x2);
                            }
                        }
                        else if(nSensoresEscolhidos == 3){
                            if (String.Equals(amostragem, "A cada segundo")){

                                decimal[] y1, y2, y3;
                                DateTime[] x1, x2, x3;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric; y2 = termopar2_numeric; y3 = lm35_numeric;
                                x1 = sensores_time; x2 = sensores_time; x3 = sensores_time;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time;
                                    y1 = termopar1_numeric;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time;
                                    y1 = termopar2_numeric;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time;
                                    y1 = lm35_numeric;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time;
                                    y1 = mediaTermopares1e2_numeric;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time;
                                    y2 = termopar1_numeric;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time;
                                    y2 = termopar2_numeric;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time;
                                    y2 = lm35_numeric;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time;
                                    y2 = mediaTermopares1e2_numeric;
                                }

                                if (sensoresEscolhidos[2].Equals("Termopar 1")){
                                    x3 = sensores_time;
                                    y3 = termopar1_numeric;
                                }
                                else if (sensoresEscolhidos[2].Equals("Termopar 2")){
                                    x3 = sensores_time;
                                    y3 = termopar2_numeric;
                                }
                                else if (sensoresEscolhidos[2].Equals("Lm35")){
                                    x3 = sensores_time;
                                    y3 = lm35_numeric;
                                }
                                else if (sensoresEscolhidos[2].Equals("Media dos termopares")){
                                    x3 = sensores_time;
                                    y3 = mediaTermopares1e2_numeric;
                                }


                                formularioGrafico1.plotarTresGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], sensoresEscolhidos[2], (int)this.numericUpDown1.Value, numeroDeLinhas,
                                    y1, x1, y2, x2, y3, x3);
                            }
                            else if (String.Equals(amostragem, "A cada dez segundos")){

                                decimal[] y1, y2, y3;
                                DateTime[] x1, x2, x3;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_10em10s; y2 = termopar2_numeric_10em10s; y3 = lm35_numeric_10em10s;
                                x1 = sensores_time_10em10s; x2 = sensores_time_10em10s; x3 = sensores_time_10em10s;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_10em10s;
                                    y1 = termopar1_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_10em10s;
                                    y1 = termopar2_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_10em10s;
                                    y1 = lm35_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_10em10s;
                                    y1 = mediaTermopares1e2_numeric_10em10s;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_10em10s;
                                    y2 = termopar1_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_10em10s;
                                    y2 = termopar2_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_10em10s;
                                    y2 = lm35_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_10em10s;
                                    y2 = mediaTermopares1e2_numeric_10em10s;
                                }



                                if (sensoresEscolhidos[2].Equals("Termopar 1")){
                                    x3 = sensores_time_10em10s;
                                    y3 = termopar1_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[2].Equals("Termopar 2")){
                                    x3 = sensores_time_10em10s;
                                    y3 = termopar2_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[2].Equals("Lm35")){
                                    x3 = sensores_time_10em10s;
                                    y3 = lm35_numeric_10em10s;
                                }
                                else if (sensoresEscolhidos[2].Equals("Media dos termopares")){
                                    x3 = sensores_time_10em10s;
                                    y3 = mediaTermopares1e2_numeric_10em10s;
                                }


                                formularioGrafico1.plotarTresGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], sensoresEscolhidos[2], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10s,
                                    y1, x1, y2, x2, y3, x3);
                            }
                            else if (String.Equals(amostragem, "A cada minuto")){

                                decimal[] y1, y2, y3;
                                DateTime[] x1, x2, x3;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_1em1min; y2 = termopar2_numeric_1em1min; y3 = lm35_numeric_1em1min;
                                x1 = sensores_time_1em1min; x2 = sensores_time_1em1min; x3 = sensores_time_1em1min;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_1em1min;
                                    y1 = termopar1_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_1em1min;
                                    y1 = termopar2_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_1em1min;
                                    y1 = lm35_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_1em1min;
                                    y1 = mediaTermopares1e2_numeric_1em1min;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_1em1min;
                                    y2 = termopar1_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_1em1min;
                                    y2 = termopar2_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_1em1min;
                                    y2 = lm35_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_1em1min;
                                    y2 = mediaTermopares1e2_numeric_1em1min;
                                }



                                if (sensoresEscolhidos[2].Equals("Termopar 1")){
                                    x3 = sensores_time_1em1min;
                                    y3 = termopar1_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Termopar 2")){
                                    x3 = sensores_time_1em1min;
                                    y3 = termopar2_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Lm35")){
                                    x3 = sensores_time_1em1min;
                                    y3 = lm35_numeric_1em1min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Media dos termopares")){
                                    x3 = sensores_time_1em1min;
                                    y3 = mediaTermopares1e2_numeric_1em1min;
                                }


                                formularioGrafico1.plotarTresGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], sensoresEscolhidos[2], (int)this.numericUpDown1.Value, numeroDeLinhas_1em1min,
                                    y1, x1, y2, x2, y3, x3);
                            }
                            else if (String.Equals(amostragem, "A cada dois minutos")){

                                decimal[] y1, y2, y3;
                                DateTime[] x1, x2, x3;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_2em2min; y2 = termopar2_numeric_2em2min; y3 = lm35_numeric_2em2min;
                                x1 = sensores_time_2em2min; x2 = sensores_time_2em2min; x3 = sensores_time_2em2min;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_2em2min;
                                    y1 = termopar1_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_2em2min;
                                    y1 = termopar2_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_2em2min;
                                    y1 = lm35_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_2em2min;
                                    y1 = mediaTermopares1e2_numeric_2em2min;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_2em2min;
                                    y2 = termopar1_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_2em2min;
                                    y2 = termopar2_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_2em2min;
                                    y2 = lm35_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_2em2min;
                                    y2 = mediaTermopares1e2_numeric_2em2min;
                                }



                                if (sensoresEscolhidos[2].Equals("Termopar 1")){
                                    x3 = sensores_time_2em2min;
                                    y3 = termopar1_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Termopar 2")){
                                    x3 = sensores_time_2em2min;
                                    y3 = termopar2_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Lm35")){
                                    x3 = sensores_time_2em2min;
                                    y3 = lm35_numeric_2em2min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Media dos termopares")){
                                    x3 = sensores_time_2em2min;
                                    y3 = mediaTermopares1e2_numeric_2em2min;
                                }


                                formularioGrafico1.plotarTresGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], sensoresEscolhidos[2], (int)this.numericUpDown1.Value, numeroDeLinhas_2em2min,
                                    y1, x1, y2, x2, y3, x3);
                            }
                            else if (String.Equals(amostragem, "A cada cinco minutos")){

                                decimal[] y1, y2, y3;
                                DateTime[] x1, x2, x3;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_5em5min; y2 = termopar2_numeric_5em5min; y3 = lm35_numeric_5em5min;
                                x1 = sensores_time_5em5min; x2 = sensores_time_5em5min; x3 = sensores_time_5em5min;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_5em5min;
                                    y1 = termopar1_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_5em5min;
                                    y1 = termopar2_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_5em5min;
                                    y1 = lm35_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_5em5min;
                                    y1 = mediaTermopares1e2_numeric_5em5min;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_5em5min;
                                    y2 = termopar1_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_5em5min;
                                    y2 = termopar2_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_5em5min;
                                    y2 = lm35_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_5em5min;
                                    y2 = mediaTermopares1e2_numeric_5em5min;
                                }



                                if (sensoresEscolhidos[2].Equals("Termopar 1")){
                                    x3 = sensores_time_5em5min;
                                    y3 = termopar1_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Termopar 2")){
                                    x3 = sensores_time_5em5min;
                                    y3 = termopar2_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Lm35")){
                                    x3 = sensores_time_5em5min;
                                    y3 = lm35_numeric_5em5min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Media dos termopares")){
                                    x3 = sensores_time_5em5min;
                                    y3 = mediaTermopares1e2_numeric_5em5min;
                                }


                                formularioGrafico1.plotarTresGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], sensoresEscolhidos[2], (int)this.numericUpDown1.Value, numeroDeLinhas_5em5min,
                                    y1, x1, y2, x2, y3, x3);
                            }
                            else if (String.Equals(amostragem, "A cada dez minutos")){

                                decimal[] y1, y2, y3;
                                DateTime[] x1, x2, x3;

                                //inicialização básica para não dar erro
                                y1 = termopar1_numeric_10em10min; y2 = termopar2_numeric_10em10min; y3 = lm35_numeric_10em10min;
                                x1 = sensores_time_10em10min; x2 = sensores_time_10em10min; x3 = sensores_time_10em10min;

                                if (sensoresEscolhidos[0].Equals("Termopar 1")){
                                    x1 = sensores_time_10em10min;
                                    y1 = termopar1_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Termopar 2")){
                                    x1 = sensores_time_10em10min;
                                    y1 = termopar2_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Lm35")){
                                    x1 = sensores_time_10em10min;
                                    y1 = lm35_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[0].Equals("Media dos termopares")){
                                    x1 = sensores_time_10em10min;
                                    y1 = mediaTermopares1e2_numeric_10em10min;
                                }



                                if (sensoresEscolhidos[1].Equals("Termopar 1")){
                                    x2 = sensores_time_10em10min;
                                    y2 = termopar1_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Termopar 2")){
                                    x2 = sensores_time_10em10min;
                                    y2 = termopar2_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Lm35")){
                                    x2 = sensores_time_10em10min;
                                    y2 = lm35_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[1].Equals("Media dos termopares")){
                                    x2 = sensores_time_10em10min;
                                    y2 = mediaTermopares1e2_numeric_10em10min;
                                }



                                if (sensoresEscolhidos[2].Equals("Termopar 1")){
                                    x3 = sensores_time_10em10min;
                                    y3 = termopar1_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Termopar 2")){
                                    x3 = sensores_time_10em10min;
                                    y3 = termopar2_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Lm35")){
                                    x3 = sensores_time_10em10min;
                                    y3 = lm35_numeric_10em10min;
                                }
                                else if (sensoresEscolhidos[2].Equals("Media dos termopares")){
                                    x3 = sensores_time_10em10min;
                                    y3 = mediaTermopares1e2_numeric_10em10min;
                                }


                                formularioGrafico1.plotarTresGraficos(sensoresEscolhidos[0], sensoresEscolhidos[1], sensoresEscolhidos[2], (int)this.numericUpDown1.Value, numeroDeLinhas_10em10min,
                                    y1, x1, y2, x2, y3, x3);
                            }
                        }
                    }

                    //Se o usuário escolheu "Usar intervalo"
                    if (checkBox2.Checked)
                    {
                        //mensagem de erro se o usuário não forneceu o intervalo
                        if (String.Equals(textBox2.Text, "") || String.Equals(textBox3.Text, "")){
                            MessageBox.Show("Forneça instantes inicial e final!", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else{

                            string instante_inicial, instante_final;
                            instante_inicial = textBox2.Text;
                            instante_final = textBox3.Text;

                            var partes_inicio = instante_inicial.Split(' ');
                            var partes_fim = instante_final.Split(' ');

                            DateTime inicio = new DateTime(sensores_time[0].Year, sensores_time[0].Month, sensores_time[0].Day,
                                int.Parse(partes_inicio[0]), int.Parse(partes_inicio[1]), int.Parse(partes_inicio[2]));
                            DateTime fim = new DateTime(sensores_time[0].Year, sensores_time[0].Month, sensores_time[0].Day,
                                int.Parse(partes_fim[0]), int.Parse(partes_fim[1]), int.Parse(partes_fim[2]));

                            //OBS: aqui algumas coisas precisam ser garantidas:
                            //      1 - "fim" deve ser maior ou igual a "inicio"
                            //      2 - "inicio" deve ser maior ou igual a sensores_time[0] e menor ou igual a sensores_time[ sensores_time.length - 1 ]
                            //      3 - "fim" também deve ser maior ou igual a sensores_time[0] e menor ou igual a sensores_time[ sensores_time.length -1 ]
                            //      Do contrário, enviar mensagem de erro e impedir de prosseguir
                            if ((inicio > fim) ||
                                ((inicio < sensores_time[0]) || (inicio > sensores_time[sensores_time.Length - 1])) ||
                                ((fim < sensores_time[0]) || (fim > sensores_time[sensores_time.Length - 1]))){

                                MessageBox.Show("Instantes inicial e final incompatíveis! \r\n\r\n Instante final deve ser " +
                                    "maior ou igual ao instante inicial, e ambos devem estar dentro dos dados disponíveis " +
                                    "conforme o relatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else{

                                Form2 formularioGrafico1 = new Form2();
                                formularioGrafico1.Show();

                                //Se o usuário escolheu plotar apenas 1 sensor...
                                if (nSensoresEscolhidos == 1){

                                    if (String.Equals(amostragem, "A cada segundo")){

                                        DateTime[] arrayCortada_X = arrayDatetimeCortada(sensores_time, inicio, fim);

                                        if (sensoresEscolhidos[0] == "Termopar 1"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada(termopar1_numeric, sensores_time, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Termopar 2"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada(termopar2_numeric, sensores_time, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if(sensoresEscolhidos[0] == "Lm35"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada(lm35_numeric, sensores_time, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Media dos termopares"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada(mediaTermopares1e2_numeric, sensores_time, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }

                                    }
                                    else if (String.Equals(amostragem, "A cada dez segundos")){

                                        DateTime[] arrayCortada_X = arrayDatetimeCortada_10em10s(sensores_time_10em10s, inicio, fim);

                                        if (sensoresEscolhidos[0] == "Termopar 1"){         
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_10em10s(termopar1_numeric_10em10s, sensores_time_10em10s, inicio,fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Termopar 2"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_10em10s(termopar2_numeric_10em10s, sensores_time_10em10s, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Lm35"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_10em10s(lm35_numeric_10em10s, sensores_time_10em10s, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Media dos termopares"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_10em10s(mediaTermopares1e2_numeric_10em10s, sensores_time_10em10s, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                    }
                                    else if (String.Equals(amostragem, "A cada minuto")){

                                        DateTime[] arrayCortada_X = arrayDatetimeCortada_1em1min(sensores_time_1em1min, inicio, fim);

                                        if (sensoresEscolhidos[0] == "Termopar 1"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_1em1min(termopar1_numeric_1em1min, sensores_time_1em1min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Termopar 2"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_1em1min(termopar2_numeric_1em1min, sensores_time_1em1min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Lm35"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_1em1min(lm35_numeric_1em1min, sensores_time_1em1min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Media dos termopares"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_1em1min(mediaTermopares1e2_numeric_1em1min, sensores_time_1em1min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                    }
                                    else if(String.Equals(amostragem, "A cada dois minutos")){

                                        DateTime[] arrayCortada_X = arrayDatetimeCortada_2em2min(sensores_time_2em2min, inicio, fim);

                                        if (sensoresEscolhidos[0] == "Termopar 1"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_2em2min(termopar1_numeric_2em2min, sensores_time_2em2min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Termopar 2"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_2em2min(termopar2_numeric_2em2min, sensores_time_2em2min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Lm35"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_2em2min(lm35_numeric_2em2min, sensores_time_2em2min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Media dos termopares"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_2em2min(mediaTermopares1e2_numeric_2em2min, sensores_time_2em2min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }

                                    }
                                    else if (String.Equals(amostragem, "A cada cinco minutos")){

                                        DateTime[] arrayCortada_X = arrayDatetimeCortada_5em5min(sensores_time_5em5min, inicio, fim);

                                        if (sensoresEscolhidos[0] == "Termopar 1"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_5em5min(termopar1_numeric_5em5min, sensores_time_5em5min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Termopar 2"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_5em5min(termopar2_numeric_5em5min, sensores_time_5em5min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Lm35"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_5em5min(lm35_numeric_5em5min, sensores_time_5em5min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                        else if (sensoresEscolhidos[0] == "Media dos termopares"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_5em5min(mediaTermopares1e2_numeric_5em5min, sensores_time_5em5min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }

                                    }
                                    else if (String.Equals(amostragem, "A cada dez minutos")){

                                        DateTime[] arrayCortada_X = arrayDatetimeCortada_10em10min(sensores_time_10em10min, inicio, fim);

                                        if (sensoresEscolhidos[0] == "Termopar 1"){
                                            decimal[] arrayCortada_Y = arrayDecimalCortada_10em10min(termopar1_numeric_10em10min, sensores_time_10em10min, inicio, fim);
                                            formularioGrafico1.plotarApenasUmGrafico(sensoresEscolhidos[0], (int)this.numericUpDown1.Value, arrayCortada_Y.Length, arrayCortada_Y, arrayCortada_X);
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }


        private decimal[] arrayDecimalCortada(decimal[] arrayEntradaY, DateTime[] arrayEntradaX, DateTime inicio, DateTime fim)
        {
            //Este método retorna a arrayEntradaY cortada. O início do corte é no tempo fornecido por "inicio", 
            //e o fim do corte é no tempo fornecido por "fim".

            double tamanhoDaArrayDeSaida = (fim - inicio).TotalSeconds + 1;
            decimal[] arrayDeSaida = new decimal[(int)tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntradaY.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntradaX[i] == inicio)
                    indice_aux_inicio = i;

                if (arrayEntradaX[i] == fim)
                    indice_aux_fim = i;
            }
            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntradaY[i];
            }

            return arrayDeSaida;
        }

        private decimal[] arrayDecimalCortada_10em10s(decimal[] arrayEntradaY, DateTime[] arrayEntradaX, DateTime inicio, DateTime fim)
        {
            // Exemplo de chamada deste método:
            // arrayDecimalCortada_10em10s(termopar1_numeric_10em10s, sensores_time_10em10s, inicio,fim);

            // Este método tem função muito semelhante ao método "arrayDecimalCortada(...)", portanto
            // a lógica de implementação será semelhante. Porém há uma adaptação a ser feita. 
            // A arrayEntradaY será a array com amostragens de 10 em 10 segundos de uma array original.
            // Por exemplo, termopar1_numeric_10em10s contém amostras de termopar1_numeric feitas a cada
            // 10 s, sendo que a primeira amostra retirada é o primeiro elemento da array original.

            // Este método é chamado em um escopo onde já ocorreu uma pré análise das entradas do usuário
            // que representam o instante inicial e o instante final, de modo a garantir que essas entradas 
            // obedeçam a algumas regras. Por exemplo, inicio deve ser menor ou igual a fim, e ambos devem
            // estar dentro do intervalo de tempo dos dados dos sensores, conforme mostrado no relatório gerado.

            // Assim, minha preocupação aqui é com o fato de que esses dados de inicio e fim fornecidos pelo
            // usuário podem não coincidir com amostras dos dados de tempo de 10 em 10 segundos a partir do
            // valor da primeira amostra. Por exemplo, arrayEntradaX pode ser uma array da seguinte forma:
            // [ 09:00:00   09:00:10   09:00:20   09:00:30    09:00:40    09:00:50 ]
            // e o usuário pode fornecer "inicio" = 09:00:18, e até mesmo pode acontecer de o valor
            // "final" ser um número maior do que o último, por exemplo, 09:00:51.
            // O QUE FAZER NESSAS OCASIÕES????
            // A resposta é: arredondar para o valor válido mais próximo!

            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntradaX[arrayEntradaX.Length - 1])
                fim = arrayEntradaX[arrayEntradaX.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = arrayEntradaX[0];
            fim_corrigido = arrayEntradaX[arrayEntradaX.Length - 1];
            int diferenca = 0;

            //talvez o método Datetime.Compare() possa ser substituido por < e > (menor e maior).
            for (int i = 0; i < arrayEntradaX.Length; i++){
                if (DateTime.Compare(inicio, arrayEntradaX[i]) >= 0){
                    if (DateTime.Compare(inicio, arrayEntradaX[i]) == 0){
                        inicio_corrigido = arrayEntradaX[i];
                        Console.WriteLine("A" + "    i= " + i);
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntradaX[i]).TotalSeconds;
                        if(diferenca <= 5){
                            inicio_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            Console.WriteLine("B" + "    i= " + i);
                            break;
                        }
                        else if(diferenca <= 10){
                            if(i != (arrayEntradaX.Length - 1)){
                                inicio_corrigido=arrayEntradaX[i+1];
                                diferenca = 0;
                                Console.WriteLine("C" + "    i= " + i);
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                Console.WriteLine("D" + "    i= " + i);
                                break;
                            }
                        }
                    }
                }
            }

            for(int i = arrayEntradaX.Length - 1; i >= 0; i--){
                Console.WriteLine("#### fim= " + fim + " #### arrayEntrada[i]= " + arrayEntradaX[i] + " #### i= " + i);
                if (DateTime.Compare(fim, arrayEntradaX[i]) <= 0){
                    if(DateTime.Compare(fim, arrayEntradaX[i]) == 0){
                        fim_corrigido = arrayEntradaX[i];
                        Console.WriteLine("F" + "    i= " + i);
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntradaX[i] - fim).TotalSeconds;
                        if(diferenca <= 5){
                            fim_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            Console.WriteLine("G" + "    i= " + i);
                            break;
                        }
                        else if(diferenca <= 10){
                            if(i != 0){
                                fim_corrigido = arrayEntradaX[i - 1];
                                diferenca = 0;
                                Console.WriteLine("H" + "    i= " + i);
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                Console.WriteLine("I" + "    i= " + i);
                                break; 
                            }
                        }
                    }
                }
            }


            // A partir daqui, proceder com a lógica usando as novas variáveis
            // inicio_corrigido e fim_corrigido

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds / 10) + 1;

            decimal[] arrayDeSaida = new decimal[tamanhoDaArrayDeSaida];

            /*
                
                         inicio                                fim
            12:12:00    12:12:10    12:12:20    12:12:30    12:12:40    12:12:50

                no caso acima, a array de saída deverá ter 4 elementos, mas 
                (fim - inicio).totalSeconds + 1     = 31

                então devo pegar   (fim-inicio).totalseconds, dividir por 10, converter em inteiro, e depois somar 1

                */

            int tamanhoDaArrayDeEntrada = arrayEntradaY.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntradaX[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntradaX[i] == fim_corrigido)
                    indice_aux_fim = i;
            }
            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntradaY[i];
            }

            return arrayDeSaida;
        }

        private decimal[] arrayDecimalCortada_1em1min(decimal[] arrayEntradaY, DateTime[] arrayEntradaX, DateTime inicio, DateTime fim)
        {
            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntradaX[arrayEntradaX.Length - 1])
                fim = arrayEntradaX[arrayEntradaX.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = arrayEntradaX[0];
            fim_corrigido = arrayEntradaX[arrayEntradaX.Length - 1];
            int diferenca = 0;

            //talvez o método Datetime.Compare() possa ser substituido por < e > (menor e maior).
            for (int i = 0; i < arrayEntradaX.Length; i++){
                if (DateTime.Compare(inicio, arrayEntradaX[i]) >= 0){
                    if (DateTime.Compare(inicio, arrayEntradaX[i]) == 0){
                        inicio_corrigido = arrayEntradaX[i];
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntradaX[i]).TotalSeconds;
                        if (diferenca <= 30){
                            inicio_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 60){
                            if (i != (arrayEntradaX.Length - 1)){
                                inicio_corrigido = arrayEntradaX[i + 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = arrayEntradaX.Length - 1; i >= 0; i--){
                if (DateTime.Compare(fim, arrayEntradaX[i]) <= 0){
                    if (DateTime.Compare(fim, arrayEntradaX[i]) == 0){
                        fim_corrigido = arrayEntradaX[i];
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntradaX[i] - fim).TotalSeconds;
                        if (diferenca <= 30){
                            fim_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 60){
                            if (i != 0){
                                fim_corrigido = arrayEntradaX[i - 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds / 60) + 1;

            decimal[] arrayDeSaida = new decimal[tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntradaY.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntradaX[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntradaX[i] == fim_corrigido)
                    indice_aux_fim = i;
            }
            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntradaY[i];
            }

            return arrayDeSaida;
        }

        private decimal[] arrayDecimalCortada_2em2min(decimal[] arrayEntradaY, DateTime[] arrayEntradaX, DateTime inicio, DateTime fim)
        {
            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntradaX[arrayEntradaX.Length - 1])
                fim = arrayEntradaX[arrayEntradaX.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = arrayEntradaX[0];
            fim_corrigido = arrayEntradaX[arrayEntradaX.Length - 1];
            int diferenca = 0;

            //talvez o método Datetime.Compare() possa ser substituido por < e > (menor e maior).
            for (int i = 0; i < arrayEntradaX.Length; i++){
                if (DateTime.Compare(inicio, arrayEntradaX[i]) >= 0){
                    if (DateTime.Compare(inicio, arrayEntradaX[i]) == 0){
                        inicio_corrigido = arrayEntradaX[i];
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntradaX[i]).TotalSeconds;
                        if (diferenca <= 60){
                            inicio_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 120){
                            if (i != (arrayEntradaX.Length - 1)){
                                inicio_corrigido = arrayEntradaX[i + 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = arrayEntradaX.Length - 1; i >= 0; i--){
                if (DateTime.Compare(fim, arrayEntradaX[i]) <= 0){
                    if (DateTime.Compare(fim, arrayEntradaX[i]) == 0){
                        fim_corrigido = arrayEntradaX[i];
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntradaX[i] - fim).TotalSeconds;
                        if (diferenca <= 60){
                            fim_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 120){
                            if (i != 0){
                                fim_corrigido = arrayEntradaX[i - 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds / 120) + 1;

            decimal[] arrayDeSaida = new decimal[tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntradaY.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntradaX[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntradaX[i] == fim_corrigido)
                    indice_aux_fim = i;
            }
            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntradaY[i];
            }

            return arrayDeSaida;
        }

        private decimal[] arrayDecimalCortada_5em5min(decimal[] arrayEntradaY, DateTime[] arrayEntradaX, DateTime inicio, DateTime fim)
        {
            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntradaX[arrayEntradaX.Length - 1])
                fim = arrayEntradaX[arrayEntradaX.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = arrayEntradaX[0];
            fim_corrigido = arrayEntradaX[arrayEntradaX.Length - 1];
            int diferenca = 0;

            //talvez o método Datetime.Compare() possa ser substituido por < e > (menor e maior).
            for (int i = 0; i < arrayEntradaX.Length; i++){
                if (DateTime.Compare(inicio, arrayEntradaX[i]) >= 0){
                    if (DateTime.Compare(inicio, arrayEntradaX[i]) == 0){
                        inicio_corrigido = arrayEntradaX[i];
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntradaX[i]).TotalSeconds;
                        if (diferenca <= 150){
                            inicio_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 300){
                            if (i != (arrayEntradaX.Length - 1)){
                                inicio_corrigido = arrayEntradaX[i + 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = arrayEntradaX.Length - 1; i >= 0; i--){
                if (DateTime.Compare(fim, arrayEntradaX[i]) <= 0){
                    if (DateTime.Compare(fim, arrayEntradaX[i]) == 0){
                        fim_corrigido = arrayEntradaX[i];
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntradaX[i] - fim).TotalSeconds;
                        if (diferenca <= 150){
                            fim_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 300){
                            if (i != 0){
                                fim_corrigido = arrayEntradaX[i - 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds / 300) + 1;

            decimal[] arrayDeSaida = new decimal[tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntradaY.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntradaX[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntradaX[i] == fim_corrigido)
                    indice_aux_fim = i;
            }
            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntradaY[i];
            }

            return arrayDeSaida;
        }

        private decimal[] arrayDecimalCortada_10em10min(decimal[] arrayEntradaY, DateTime[] arrayEntradaX, DateTime inicio, DateTime fim)
        {
            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntradaX[arrayEntradaX.Length - 1])
                fim = arrayEntradaX[arrayEntradaX.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = arrayEntradaX[0];
            fim_corrigido = arrayEntradaX[arrayEntradaX.Length - 1];
            int diferenca = 0;

            //talvez o método Datetime.Compare() possa ser substituido por < e > (menor e maior).
            for (int i = 0; i < arrayEntradaX.Length; i++){
                if (DateTime.Compare(inicio, arrayEntradaX[i]) >= 0){
                    if (DateTime.Compare(inicio, arrayEntradaX[i]) == 0){
                        inicio_corrigido = arrayEntradaX[i];
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntradaX[i]).TotalSeconds;
                        if (diferenca <= 300){
                            inicio_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 600){
                            if (i != (arrayEntradaX.Length - 1)){
                                inicio_corrigido = arrayEntradaX[i + 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = arrayEntradaX.Length - 1; i >= 0; i--){
                if (DateTime.Compare(fim, arrayEntradaX[i]) <= 0){
                    if (DateTime.Compare(fim, arrayEntradaX[i]) == 0){
                        fim_corrigido = arrayEntradaX[i];
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntradaX[i] - fim).TotalSeconds;
                        if (diferenca <= 300){
                            fim_corrigido = arrayEntradaX[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 600){
                            if (i != 0){
                                fim_corrigido = arrayEntradaX[i - 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntradaX[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds / 600) + 1;

            decimal[] arrayDeSaida = new decimal[tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntradaY.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntradaX[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntradaX[i] == fim_corrigido)
                    indice_aux_fim = i;
            }
            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntradaY[i];
            }

            return arrayDeSaida;
        }



        private DateTime[] arrayDatetimeCortada(DateTime[] arrayEntrada, DateTime inicio, DateTime fim)
        {
            double tamanhoDaArrayDeSaida = (fim - inicio).TotalSeconds + 1;
            DateTime[] arrayDeSaida = new DateTime[(int)tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntrada.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntrada[i] == inicio)
                    indice_aux_inicio = i;

                if (arrayEntrada[i] == fim)
                    indice_aux_fim = i;
            }

            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            Console.WriteLine("indice_aux_inicio: " + indice_aux_inicio);
            Console.WriteLine("indice_aux_fim: " + indice_aux_fim);
            Console.WriteLine("arrayDeSaida.Length: " + arrayDeSaida.Length);
            Console.WriteLine("arrayEntrada.Length: " + arrayEntrada.Length);
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");

            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntrada[i];
            }
            return arrayDeSaida;
        }

        private DateTime[] arrayDatetimeCortada_10em10s(DateTime[] arrayEntrada, DateTime inicio, DateTime fim)
        {
            // Exemplo de chamada deste método:
            // arrayDatetimeCortada_10em10s(sensores_time_10em10s, inicio, fim);

            // A lógica deste método é semelhante à lógica do método arrayDecimalCortada_10em10s(...)
            // e na implementação daquele método há comentários explicando com mais detalhes.

            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntrada[arrayEntrada.Length - 1])
                fim = arrayEntrada[arrayEntrada.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = inicio;
            fim_corrigido = arrayEntrada[arrayEntrada.Length - 1];
            int diferenca = 0;

            for (int i=0; i<arrayEntrada.Length; i++){
                if(inicio >= arrayEntrada[i]){
                    if(inicio == arrayEntrada[i]){
                        inicio_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntrada[i]).TotalSeconds;
                        if(diferenca <= 5){
                            inicio_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if(diferenca <= 10){
                            if(i != (arrayEntrada.Length - 1)){
                                inicio_corrigido = arrayEntrada[i + 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for(int i = arrayEntrada.Length - 1; i>=0; i--){
                if(fim <= arrayEntrada[i]){
                    if(fim == arrayEntrada[i]){
                        fim_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntrada[i] - fim).TotalSeconds;
                        if(diferenca <= 5){
                            fim_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if(diferenca <= 10){
                            if (i != 0){
                                fim_corrigido = arrayEntrada[i - 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds/10) + 1;
            DateTime[] arrayDeSaida = new DateTime[tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntrada.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntrada[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntrada[i] == fim_corrigido)
                    indice_aux_fim = i;
            }

            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            Console.WriteLine("indice_aux_inicio: " + indice_aux_inicio);
            Console.WriteLine("indice_aux_fim: " + indice_aux_fim);
            Console.WriteLine("arrayDeSaida.Length: " + arrayDeSaida.Length);
            Console.WriteLine("arrayEntrada.Length: " + arrayEntrada.Length);
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");

            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntrada[i];
            }
            return arrayDeSaida;
        }
        
        private DateTime[] arrayDatetimeCortada_1em1min(DateTime[] arrayEntrada, DateTime inicio, DateTime fim)
        {
            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntrada[arrayEntrada.Length - 1])
                fim = arrayEntrada[arrayEntrada.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = inicio;
            fim_corrigido = arrayEntrada[arrayEntrada.Length - 1];
            int diferenca = 0;

            for (int i = 0; i < arrayEntrada.Length; i++){
                if (inicio >= arrayEntrada[i]){
                    if (inicio == arrayEntrada[i]){
                        inicio_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntrada[i]).TotalSeconds;
                        if (diferenca <= 30){
                            inicio_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 60){
                            if (i != (arrayEntrada.Length - 1)){
                                inicio_corrigido = arrayEntrada[i + 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = arrayEntrada.Length - 1; i >= 0; i--){
                if (fim <= arrayEntrada[i]){
                    if (fim == arrayEntrada[i]){
                        fim_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntrada[i] - fim).TotalSeconds;
                        if (diferenca <= 30){
                            fim_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 60){
                            if (i != 0){
                                fim_corrigido = arrayEntrada[i - 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds / 60) + 1;
            DateTime[] arrayDeSaida = new DateTime[tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntrada.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntrada[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntrada[i] == fim_corrigido)
                    indice_aux_fim = i;
            }

            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            Console.WriteLine("indice_aux_inicio: " + indice_aux_inicio);
            Console.WriteLine("indice_aux_fim: " + indice_aux_fim);
            Console.WriteLine("arrayDeSaida.Length: " + arrayDeSaida.Length);
            Console.WriteLine("arrayEntrada.Length: " + arrayEntrada.Length);
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");

            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntrada[i];
            }

            return arrayDeSaida;
        }

        private DateTime[] arrayDatetimeCortada_2em2min(DateTime[] arrayEntrada, DateTime inicio, DateTime fim)
        {
            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntrada[arrayEntrada.Length - 1])
                fim = arrayEntrada[arrayEntrada.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = inicio;
            fim_corrigido = arrayEntrada[arrayEntrada.Length - 1];
            int diferenca = 0;

            for (int i = 0; i < arrayEntrada.Length; i++){
                if (inicio >= arrayEntrada[i]){
                    if (inicio == arrayEntrada[i]){
                        inicio_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntrada[i]).TotalSeconds;
                        if (diferenca <= 60){
                            inicio_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 120){
                            if (i != (arrayEntrada.Length - 1)){
                                inicio_corrigido = arrayEntrada[i + 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = arrayEntrada.Length - 1; i >= 0; i--){
                if (fim <= arrayEntrada[i]){
                    if (fim == arrayEntrada[i]){
                        fim_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntrada[i] - fim).TotalSeconds;
                        if (diferenca <= 60){
                            fim_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 120){
                            if (i != 0){
                                fim_corrigido = arrayEntrada[i - 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds / 120) + 1;
            DateTime[] arrayDeSaida = new DateTime[tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntrada.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntrada[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntrada[i] == fim_corrigido)
                    indice_aux_fim = i;
            }

            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            Console.WriteLine("indice_aux_inicio: " + indice_aux_inicio);
            Console.WriteLine("indice_aux_fim: " + indice_aux_fim);
            Console.WriteLine("arrayDeSaida.Length: " + arrayDeSaida.Length);
            Console.WriteLine("arrayEntrada.Length: " + arrayEntrada.Length);
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");

            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntrada[i];
            }

            return arrayDeSaida;
        }

        private DateTime[] arrayDatetimeCortada_5em5min(DateTime[] arrayEntrada, DateTime inicio, DateTime fim)
        {
            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntrada[arrayEntrada.Length - 1])
                fim = arrayEntrada[arrayEntrada.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = inicio;
            fim_corrigido = arrayEntrada[arrayEntrada.Length - 1];
            int diferenca = 0;

            for (int i = 0; i < arrayEntrada.Length; i++){
                if (inicio >= arrayEntrada[i]){
                    if (inicio == arrayEntrada[i]){
                        inicio_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntrada[i]).TotalSeconds;
                        if (diferenca <= 150){
                            inicio_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 300){
                            if (i != (arrayEntrada.Length - 1)){
                                inicio_corrigido = arrayEntrada[i + 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = arrayEntrada.Length - 1; i >= 0; i--){
                if (fim <= arrayEntrada[i]){
                    if (fim == arrayEntrada[i]){
                        fim_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntrada[i] - fim).TotalSeconds;
                        if (diferenca <= 150){
                            fim_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 300){
                            if (i != 0){
                                fim_corrigido = arrayEntrada[i - 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds / 300) + 1;
            DateTime[] arrayDeSaida = new DateTime[tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntrada.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntrada[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntrada[i] == fim_corrigido)
                    indice_aux_fim = i;
            }

            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntrada[i];
            }

            return arrayDeSaida;
        }

        private DateTime[] arrayDatetimeCortada_10em10min(DateTime[] arrayEntrada, DateTime inicio, DateTime fim)
        {
            DateTime inicio_corrigido;
            DateTime fim_corrigido;

            //talvez este if não seja necessário
            if (fim >= arrayEntrada[arrayEntrada.Length - 1])
                fim = arrayEntrada[arrayEntrada.Length - 1];

            //inicialização básica para não dar erro:
            inicio_corrigido = inicio;
            fim_corrigido = arrayEntrada[arrayEntrada.Length - 1];
            int diferenca = 0;

            for (int i = 0; i < arrayEntrada.Length; i++){
                if (inicio >= arrayEntrada[i]){
                    if (inicio == arrayEntrada[i]){
                        inicio_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(inicio - arrayEntrada[i]).TotalSeconds;
                        if (diferenca <= 300){
                            inicio_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 600){
                            if (i != (arrayEntrada.Length - 1)){
                                inicio_corrigido = arrayEntrada[i + 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                inicio_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = arrayEntrada.Length - 1; i >= 0; i--){
                if (fim <= arrayEntrada[i]){
                    if (fim == arrayEntrada[i]){
                        fim_corrigido = arrayEntrada[i];
                        break;
                    }
                    else{
                        diferenca = (int)(arrayEntrada[i] - fim).TotalSeconds;
                        if (diferenca <= 300){
                            fim_corrigido = arrayEntrada[i];
                            diferenca = 0;
                            break;
                        }
                        else if (diferenca <= 600){
                            if (i != 0){
                                fim_corrigido = arrayEntrada[i - 1];
                                diferenca = 0;
                                break;
                            }
                            else{
                                fim_corrigido = arrayEntrada[i];
                                diferenca = 0;
                                break;
                            }
                        }
                    }
                }
            }

            int tamanhoDaArrayDeSaida = (int)((fim_corrigido - inicio_corrigido).TotalSeconds / 600) + 1;
            DateTime[] arrayDeSaida = new DateTime[tamanhoDaArrayDeSaida];

            int tamanhoDaArrayDeEntrada = arrayEntrada.Length;

            int indice_aux_inicio = 0;
            int indice_aux_fim = 0;
            for (int i = 0; i < tamanhoDaArrayDeEntrada; i++){
                if (arrayEntrada[i] == inicio_corrigido)
                    indice_aux_inicio = i;

                if (arrayEntrada[i] == fim_corrigido)
                    indice_aux_fim = i;
            }

            for (int i = indice_aux_inicio; i <= indice_aux_fim; i++){
                arrayDeSaida[i - indice_aux_inicio] = arrayEntrada[i];
            }

            return arrayDeSaida;
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //if (numericUpDown1.Value < 1) 
            //    numericUpDown1.Value = 1;
            //else if(numericUpDown1.Value >20)
            //    numericUpDown1.Value=20;
        }
    }
}
