using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Linq;  
using System.Linq.Expressions;


namespace ProvaAdmissionalCSharpApisul
{


    public class ElevadorService: IElevadorService {
            public int andar {get; set;}
        
            public char elevador {get; set;}
        
            public char turno {get; set;}


            public List<int> andarMenosUtilizado(){
                
                Dictionary<int, int> Dict = new Dictionary<int,int>();

                var entrevistados = LoadJson();

                foreach (var item in entrevistados)
                {
                    if(!Dict.ContainsKey(item.andar)){
                        Dict.Add(item.andar, 1);
                    } 
                    else {
                        Dict[item.andar]++;
                    }
                }


                int minimoutilizado = int.MaxValue;

                foreach (var item in Dict)
                {
                    minimoutilizado = minimoutilizado > item.Value ? 
                    item.Value : minimoutilizado; 
                  
                }

                List<int> andaresMenosVisitados = Dict.Where(
                    x => x.Value == minimoutilizado)
                    .Select(x => x.Key)
                    .ToList();


                return andaresMenosVisitados;
             }


            public List<char> elevadorMaisFrequentado(){
                Dictionary<char, int> Dict = new Dictionary<char,int>();

                var entrevistados = LoadJson();

                foreach (var item in entrevistados)
                {
                    if(!Dict.ContainsKey(item.elevador)){
                        Dict.Add(item.elevador, 1);
                    } 
                    else {
                        Dict[item.elevador]++;
                    }
                }


                int maximoutilizado = int.MinValue;

                foreach (var item in Dict)
                {
                    maximoutilizado = maximoutilizado < item.Value ? 
                    item.Value : maximoutilizado; 
                  
                }

                List<char> elevadorFrequentado = Dict.Where(
                    x => x.Value == maximoutilizado)
                    .Select(x => x.Key)
                    .ToList();

                foreach (var item in elevadorFrequentado)
                {   
                    Console.WriteLine(item);
                }

                return elevadorFrequentado;
             }
            
            public List<char> elevadorMenosFrequentado(){
                Dictionary<char, int> Dict = new Dictionary<char,int>();

                var entrevistados = LoadJson();

                foreach (var item in entrevistados)
                {
                    if(!Dict.ContainsKey(item.elevador)){
                        Dict.Add(item.elevador, 1);
                    } 
                    else {
                        Dict[item.elevador]++;
                    }
                }


                int minimoutilizado = int.MaxValue;

                foreach (var item in Dict)
                {
                    minimoutilizado = minimoutilizado > item.Value ? 
                    item.Value : minimoutilizado; 
                  
                }

                List<char> elevadorMenosFrequentado = Dict.Where(
                    x => x.Value == minimoutilizado)
                    .Select(x => x.Key)
                    .ToList();


                return elevadorMenosFrequentado;
             }


            public List<char> periodoMaiorFluxoElevadorMaisFrequentado(){

                List<char> TurnosMaisFrenquentados = new List<char>();

                int[] quant = new int[3];
                
                List<char> maisFluxo = elevadorMaisFrequentado();

                var entrevistados = LoadJson();

                entrevistados = entrevistados.Where(e => maisFluxo.Contains(e.elevador)).ToList();

                for(int i =0; i < maisFluxo.Count; i++){

                    quant[0] = entrevistados.Where(e=> e.elevador == maisFluxo[i] && e.turno== 'M').Count();
                    quant[1] = entrevistados.Where(e=> e.elevador == maisFluxo[i] && e.turno== 'V').Count();
                    quant[2] = entrevistados.Where(e=> e.elevador == maisFluxo[i] && e.turno== 'N').Count();
                    
                    int maximo = quant.Max();

                    if(quant[0] == maximo) {
                        TurnosMaisFrenquentados.Add('M');
                    }

                    if(quant[1] == maximo) {
                        TurnosMaisFrenquentados.Add('V');
                    }

                    if(quant[2] == maximo) {
                        TurnosMaisFrenquentados.Add('N');
                    }

                }
                

                return TurnosMaisFrenquentados;
            }
         
            public List<char> periodoMenorFluxoElevadorMenosFrequentado(){

                List<char> TurnosMenosFrenquentados = new List<char>();

                int[] quant = new int[3];
                
                List<char> menosFluxo = elevadorMenosFrequentado();

                var entrevistados = LoadJson();

                entrevistados = entrevistados.Where(e => menosFluxo.Contains(e.elevador)).ToList();

                for(int i =0; i < menosFluxo.Count; i++){

                    quant[0] = entrevistados.Where(e=> e.elevador == menosFluxo[i] && e.turno== 'M').Count();
                    quant[1] = entrevistados.Where(e=> e.elevador == menosFluxo[i] && e.turno== 'V').Count();
                    quant[2] = entrevistados.Where(e=> e.elevador == menosFluxo[i] && e.turno== 'N').Count();
                    
                    int minimo = quant.Min();

                    if(quant[0] == minimo) {
                        TurnosMenosFrenquentados.Add('M');
                    }

                    if(quant[1] == minimo) {
                        TurnosMenosFrenquentados.Add('V');
                    }

                    if(quant[2] == minimo) {
                        TurnosMenosFrenquentados.Add('N');
                    }

                }
                

                return TurnosMenosFrenquentados;
            }

            public List<char> periodoMaiorUtilizacaoConjuntoElevadores(){
                Dictionary<char, int> Dict = new Dictionary<char,int>();

                var entrevistados = LoadJson();

                foreach (var item in entrevistados)
                {
                    if(!Dict.ContainsKey(item.turno)){
                        Dict.Add(item.turno, 1);
                    } 
                    else {
                        Dict[item.turno]++;
                    }
                }


                int maximoutilizado = int.MinValue;

                foreach (var item in Dict)
                {
                    maximoutilizado = maximoutilizado < item.Value ? 
                    item.Value : maximoutilizado; 
                  
                }

                List<char> turnoMaisFrequentado = Dict.Where(
                    x => x.Value == maximoutilizado)
                    .Select(x => x.Key)
                    .ToList();

                foreach (var item in turnoMaisFrequentado)
                {   
                    Console.WriteLine(item);
                }

                return turnoMaisFrequentado;
             }

            public float percentualDeUsoElevadorA(){
                var entrevistados = LoadJson();

                int qtdElevador = 0;

                foreach (var item in entrevistados)
                {
                    if(item.elevador == 'A'){
                        qtdElevador++;
                    }
                }

                float percentual = (float) qtdElevador/entrevistados.Count;

                percentual = (float)Math.Round(percentual * 100f) / 100f;

                return percentual;
            }

            public float percentualDeUsoElevadorB(){
                var entrevistados = LoadJson();

                int qtdElevador = 0;

                foreach (var item in entrevistados)
                {
                    if(item.elevador == 'B'){
                        qtdElevador++;
                    }
                }

                float percentual = (float) qtdElevador/entrevistados.Count;

                percentual = (float)Math.Round(percentual * 100f) / 100f;

                return percentual;
            }

            public float percentualDeUsoElevadorC(){
                var entrevistados = LoadJson();

                int qtdElevador = 0;

                foreach (var item in entrevistados)
                {
                    if(item.elevador == 'C'){
                        qtdElevador++;
                    }
                }

                float percentual = (float) qtdElevador/entrevistados.Count;

                percentual = (float)Math.Round(percentual * 100f) / 100f;

                return percentual;
            }

            public float percentualDeUsoElevadorD(){
                var entrevistados = LoadJson();

                int qtdElevador = 0;

                foreach (var item in entrevistados)
                {
                    if(item.elevador == 'D'){
                        qtdElevador++;
                    }
                }

                float percentual = (float) qtdElevador/entrevistados.Count;

                percentual = (float)Math.Round(percentual * 100f) / 100f;

                return percentual;
            }

            public float percentualDeUsoElevadorE(){
                var entrevistados = LoadJson();

                int qtdElevador = 0;

                foreach (var item in entrevistados)
                {
                    if(item.elevador == 'E'){
                        qtdElevador++;
                    }
                }

                float percentual = (float) qtdElevador/entrevistados.Count;

                percentual = (float)Math.Round(percentual * 100f) / 100f;

                return percentual;
            }


            public static List<ElevadorService> LoadJson()
            { 
                List<ElevadorService> entrevistados = new List<ElevadorService>();
                using (StreamReader json = new StreamReader("../input.json"))
                {
                    string jsonObject = json.ReadToEnd();
                    entrevistados = JsonConvert.DeserializeObject<List<ElevadorService>>(jsonObject);
                }

            return entrevistados;
        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            ElevadorService elevadorService = new ElevadorService();
        }
    }
}
