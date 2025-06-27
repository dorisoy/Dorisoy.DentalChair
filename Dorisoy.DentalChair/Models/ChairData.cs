namespace Dorisoy.DentalChair.Models;

public class ChairData
{
    public bool HeightOrientation { get; set; }
    public bool AngleOrientation { get; set; }
    public int AngleValue { get; set; }
    public int HeightValue { get; set; }
    public int WaterTemperatureValue { get; set; }
    public int WaterPressureValue { get; set; }
    public int AirPressureValue { get; set; }
    public int SpeedValue { get; set; }
    public int TorqueValue { get; set; }
    public Tuple<bool, bool, bool, bool>? HandpieceType { get; set; }
    public int VoltageValue { get; set; }
    public double CurrentValue { get; set; }
}
