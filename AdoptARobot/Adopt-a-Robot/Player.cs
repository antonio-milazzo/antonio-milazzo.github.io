namespace Adopt_a_Robot
{
    class Player
    {
        public string Name;
        public Robot PlayerRobot;

        public Player()
        {
            PlayerRobot = new Robot("Robot Mach II", "Silver");
        }
    }
}