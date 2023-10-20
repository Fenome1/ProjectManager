﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectManager.Desktop.Services;

namespace ProjectManager.Desktop.Models;

public partial class Agency : ObservableObject
{
    public int IdAgency { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    [ObservableProperty] private List<Project> _projects;

    public async Task LoadProjectsAsync()
    {
        var projects = await ProjectService.GetProjectsByAgencyIdAsync(IdAgency);
        Projects = projects;
    }
}