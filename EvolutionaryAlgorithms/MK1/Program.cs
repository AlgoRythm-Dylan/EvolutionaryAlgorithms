/*
 * 
 * MK1 is purely a proof of concept to build atop
 * which intentionally lacks a generic design or any
 * intelligent evolution mechanisms. Or good code.
 * 
 * Essentially, synths are given three "random number" genes,
 * which are able to generate a number between 0 and 2.
 * 
 * Unknown to them, they are trying to make their genes
 * add up to the number 1. They are scored by using a parabola
 * which peaks at 1
 * 
 * y = -(x - 2)^2 + 1
 * 
 * After each generation, the top two performers are kept
 * and their genes are averaged to create a single offspring
 * 
 * Due to being largely outnumbered by random genes, these
 * offspring are not often responsible for the solution
 * 
 */
namespace MK1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            World world = new World();
            world.MaterializeInitialPopulation(new(){ Random = 5 });
            int count = 0;
            while (world.RunGeneration() < 0.99 && count < 100) count++;
        }
    }
}
