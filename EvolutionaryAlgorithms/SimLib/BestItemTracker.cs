namespace SimLib
{
    internal class BestItemTracker<T>
        where T : IComparable<T>
    {
        private bool IsFirstItem { get; set; } = true;
        private T Best;

        public bool Minimize { get; set; } = true;

        public void Update(T candidate)
        {
            if (IsFirstItem)
            {
                Best = candidate;
                IsFirstItem = false;
            }
            else
            {
                var comparison = candidate.CompareTo(Best);
                if(Minimize)
                {
                    if(comparison < 0)
                    {
                        Best = candidate;
                    }
                }
                else
                {
                    if(comparison > 0)
                    {
                        Best = candidate;
                    }
                }
            }
        }

        public T GetBest()
        {
            return Best;
        }
    }
}
