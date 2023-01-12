using Entities.TwoD;

namespace Ext
{
    public static class ConsoleVectorExt
    {
        public static TwoDimensionVector Output(this TwoDimensionVector item, string name)
        {
            Console.Write($"{name}: X={item.X}\t");
            return item;
        }

        public static TwoDimensionVector OutputLine(this TwoDimensionVector item, string name)
        {
            item.Output(name);
            Console.WriteLine();
            return item;
        }
    }
}