class Program
{
    static void Main()
    {
        Planet mercury = new Planet();
        mercury._name = "Mercury";
        mercury._diameter = 4879.23;

        Planet venus = new Planet();
        venus._name = "Venus";
        venus._diameter = 12104.23;

        Planet earth = new Planet();
        earth._name = "Earth";
        earth._diameter = 12742.01;
        
        SolarSystem solarSystem = new SolarSystem();
        solarSystem._solarSystem.Add(mercury);
        solarSystem._solarSystem.Add(venus);
        solarSystem._solarSystem.Add(earth);

        solarSystem.DisplaySolarSystem();
    }  
}
