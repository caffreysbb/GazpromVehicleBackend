﻿namespace GazpromVehicleBackend.Shared.Models.Requests;

public class RemoveVehicleRequest
{
    public int VehicleId { get; set; }
    public string RegNumber { get; set; }
}