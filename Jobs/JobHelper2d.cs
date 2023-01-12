using Entities;
using Entities.TwoD;
using Newtonsoft.Json;

namespace Jobs
{
    public static class JobHelper2d 
    {
        public static List<Ball<TwoDimensionVector>> GenerateRandomBalls(int count)
        {
            List<Ball<TwoDimensionVector>> result = new List<Ball<TwoDimensionVector>>();
            Random rand = new Random();
            
            for (int i = 0; i < count; i++)
            {
                Ball<TwoDimensionVector> ball = new Ball<TwoDimensionVector>()
                {
                    Density = 9999,
                    Mass = rand.Next(1500, 19999),
                    Position = new TwoDimensionVector()
                    {
                        X = rand.Next(-80, 80),
                        Y = rand.Next(-50, 50)
                    }
                };

                result.Add(ball);
            }

            return result;
        }

        public static void Dump(List<Ball<TwoDimensionVector>> balls)
        {
            string filename = @$"Balls_{balls.Count}_{DateTime.Now}.json";
            foreach (var chara in Path.GetInvalidFileNameChars())
            {
                filename = filename.Replace(chara, '-');
            }

            Directory.CreateDirectory("dump");
            using (StreamWriter file = File.CreateText("dump//"+filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, balls);
            }
        }

        public static List<Ball<TwoDimensionVector>>? Load(string filename)
        {
            using (StreamReader file = File.OpenText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize(file, typeof(List<Ball<TwoDimensionVector>>)) as List<Ball<TwoDimensionVector>>;
            }
        }
    }
}