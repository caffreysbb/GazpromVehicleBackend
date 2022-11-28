﻿using GazpromVehicleBackEnd.DataAccessLayer;
using GazpromVehicleBackEnd.DataAccessLayer.Entity;
using GazpromVehicleBackend.Shared.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace GazpromVehicleBackend.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddVehicle(AddVehicleRequest request)
    {
        if (string.IsNullOrEmpty(request.Brand) || string.IsNullOrEmpty(request.RegistrationNumber)) return false;

        var vehicle = new Vehicle
        {
            Brand = request.Brand,
            RegistrationNumber = request.RegistrationNumber
        };

        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemoveVehicleById(int id)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        if (vehicle == null) return false;

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return true;
    }

}