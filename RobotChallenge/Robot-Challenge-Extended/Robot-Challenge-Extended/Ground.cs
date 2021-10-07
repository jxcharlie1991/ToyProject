namespace Robot_Challenge_Extended
{
    class Ground
    {
        public static bool CheckOntable(int x, int y)
        {
            if (x >= 0 && x <= 4 && y >= 0 && y <= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
