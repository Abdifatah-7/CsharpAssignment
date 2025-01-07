
using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using PresentionConsole_ContactManager.Dialogs;


var serviceProvider = new ServiceCollection()
    .AddSingleton<IFileService>(new FileService("Data", "contacts.json"))
    .AddSingleton<IContactService, ContactService>()
    .AddTransient<MenuDialog>()
    .BuildServiceProvider();

var menuDialog = serviceProvider.GetRequiredService<MenuDialog>();

menuDialog.RunMenu();
