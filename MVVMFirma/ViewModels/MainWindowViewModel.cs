using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using MVVMFirma.ViewModels.ShowAll;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.ViewModels;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        private ReadOnlyCollection<CommandViewModel> _Commands;
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()
        {
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    "Sprzedane Produkty",
                    new BaseCommand(() => this.CreateView(new RaportSprzedanychSztukViewModel()))),

                new CommandViewModel(
                    "Statusy Zamówień",
                    new BaseCommand(() => this.CreateView(new RaportStatusowZamowienViewModel()))),

                new CommandViewModel(
                    "Historia Zamówień",
                    new BaseCommand(() => this.CreateView(new RaportHistoriiZamowienViewModel()))),

                new CommandViewModel(
                    "Klienci",
                    new BaseCommand(() => this.ShowAllKlient()), "👥"),

                new CommandViewModel(
                    "Klient",
                    new BaseCommand(() => this.CreateView(new NowyKlientViewModel())), "👥"),

                new CommandViewModel(
                    "Osoby Fizyczne",
                    new BaseCommand(() => this.ShowAllOsobaFizyczna()), "🙋"),

                new CommandViewModel(
                    "Osoba Fizyczna",
                    new BaseCommand(() => this.CreateView(new NowaOsobaFizycznaViewModel())), "🙋"),

                new CommandViewModel(
                    "Firmy",
                    new BaseCommand(() => this.ShowAllFirma()), "🏢"),

                new CommandViewModel(
                    "Firma",
                    new BaseCommand(() => this.CreateView(new NowaFirmaViewModel())), "🏢"),

                new CommandViewModel(
                    "Zamówienia",
                    new BaseCommand(() => this.ShowAllZamowienie()), "🛒"),

                new CommandViewModel(
                    "Zamówienie",
                    new BaseCommand(() => this.CreateView(new NoweZamowienieViewModel())), "🛒"),

                new CommandViewModel(
                    "Pozycje zamówienia",
                    new BaseCommand(() => this.ShowAllPozycjaZamowienia()), "🗂️"),

                new CommandViewModel(
                    "Pozycja zamówienia",
                    new BaseCommand(() => this.CreateView(new NowaPozycjaZamowieniaViewModel())), "🗂️"),

                new CommandViewModel(
                    "Produkty",
                    new BaseCommand(() => this.ShowAllProdukt()), "📦"),

                new CommandViewModel(
                    "Produkt",
                    new BaseCommand(() => this.CreateView(new NowyProduktViewModel())), "📦"),

                new CommandViewModel(
                    "Karty Graficzne",
                    new BaseCommand(() => this.ShowAllKartyGraficzne()), "🎨"),

                new CommandViewModel(
                    "Karta Graficzna",
                    new BaseCommand(() => this.CreateView(new NowaKartaGraficznaViewModel())), "🎨"),

                new CommandViewModel(
                    "Procesory",
                    new BaseCommand(() => this.ShowAllProcesor()), "🧠"),

                new CommandViewModel(
                    "Procesor",
                    new BaseCommand(() => this.CreateView(new NowyProcesorViewModel())), "🧠"),

                new CommandViewModel(
                    "Pamięci RAM",
                    new BaseCommand(() => this.ShowAllPamiecRAM()), "🧮"),

                new CommandViewModel(
                    "Pamięć RAM",
                    new BaseCommand(() => this.CreateView(new NowaPamiecRAMViewModel())), "🧮"),

                new CommandViewModel(
                    "Dyski",
                    new BaseCommand(() => this.ShowAllDysk()), "💽"),

                new CommandViewModel(
                    "Dysk",
                    new BaseCommand(() => this.CreateView(new NowyDyskViewModel())), "💽"),

                new CommandViewModel(
                    "Płyty Główne",
                    new BaseCommand(() => this.ShowAllPlytaGlowna()), "🖧"),

                new CommandViewModel(
                    "Płyta Główna",
                    new BaseCommand(() => this.CreateView(new NowaPlytaGlownaViewModel())), "🖧"),

                new CommandViewModel(
                    "Metody Płatności",
                    new BaseCommand(() => this.ShowAllMetodaPlatnosci()), "💳"),

                new CommandViewModel(
                    "Metoda Płatności",
                    new BaseCommand(() => this.CreateView(new NowaMetodaPlatnosciViewModel())), "💳"),

                new CommandViewModel(
                    "Promocje",
                    new BaseCommand(() => this.ShowAllPromocja()), "🔖"),

                new CommandViewModel(
                    "Promocja",
                    new BaseCommand(() => this.CreateView(new NowaPromocjaViewModel())), "🔖"),

                new CommandViewModel(
                    "Adresy",
                    new BaseCommand(() => this.ShowAllAdres()), "🏠"),

                new CommandViewModel(
                    "Adres",
                    new BaseCommand(() => this.CreateView(new NowyAdresViewModel())), "🏠"),

                new CommandViewModel(
                    "Statusy",
                    new BaseCommand(() => this.ShowAllStatus()), "🔄"),

                new CommandViewModel(
                    "Status",
                    new BaseCommand(() => this.CreateView(new NowyStatusViewModel())), "🔄"),

                new CommandViewModel(
                    "Pracownicy",
                    new BaseCommand(() => this.ShowAllPracownik()), "👨‍💼"),

                new CommandViewModel(
                    "Pracownik",
                    new BaseCommand(() => this.CreateView(new NowyPracownikViewModel())), "👨‍💼")
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void CreateView(WorkspaceViewModel nowy)
        {
            this.Workspaces.Add(nowy);
            this.SetActiveWorkspace(nowy);
        }

        private void ShowAllProdukt()
        {
            WszystkieProduktyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieProduktyViewModel)
                as WszystkieProduktyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieProduktyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllAdres()
        {
            WszystkieAdresyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel)
                as WszystkieAdresyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllMetodaPlatnosci()
        {
            WszystkieMetodyPlatnosciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieMetodyPlatnosciViewModel)
                as WszystkieMetodyPlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieMetodyPlatnosciViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPromocja()
        {
            WszystkiePromocjeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePromocjeViewModel)
                as WszystkiePromocjeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePromocjeViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllStatus()
        {
            WszystkieStatusyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieStatusyViewModel)
                as WszystkieStatusyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStatusyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllKartyGraficzne()
        {
            WszystkieKartyGraficzneViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieKartyGraficzneViewModel)
                as WszystkieKartyGraficzneViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKartyGraficzneViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllProcesor()
        {
            WszystkieProcesoryViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieProcesoryViewModel)
                as WszystkieProcesoryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieProcesoryViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPamiecRAM()
        {
            WszystkiePamieciRAMViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePamieciRAMViewModel)
                as WszystkiePamieciRAMViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePamieciRAMViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllDysk()
        {
            WszystkieDyskiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieDyskiViewModel)
                as WszystkieDyskiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieDyskiViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPlytaGlowna()
        {
            WszystkiePlytyGlowneViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePlytyGlowneViewModel)
                as WszystkiePlytyGlowneViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePlytyGlowneViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllKlient()
        {
            WszyscyKlienciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyKlienciViewModel)
                as WszyscyKlienciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKlienciViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllOsobaFizyczna()
        {
            WszystkieOsobyFizyczneViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieOsobyFizyczneViewModel)
                as WszystkieOsobyFizyczneViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieOsobyFizyczneViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFirma()
        {
            WszystkieFirmyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieFirmyViewModel)
                as WszystkieFirmyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFirmyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllZamowienie()
        {
            WszystkieZamowieniaViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieZamowieniaViewModel)
                as WszystkieZamowieniaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieZamowieniaViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPozycjaZamowienia()
        {
            WszystkiePozycjeZamowieniaViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePozycjeZamowieniaViewModel)
                as WszystkiePozycjeZamowieniaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePozycjeZamowieniaViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPracownik()
        {
            WszyscyPracownicyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel)
                as WszyscyPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void open(string name)
        {
            if (name == "ProduktyAdd")
                CreateView(new NowyProduktViewModel());
            if (name == "AdresyAdd")
                CreateView(new NowyAdresViewModel());
            if (name == "MetodyPlatnosciAdd")
                CreateView(new NowaMetodaPlatnosciViewModel());
            if (name == "PromocjeAdd")
                CreateView(new NowaPromocjaViewModel());
            if (name == "StatusyAdd")
                CreateView(new NowyStatusViewModel());
            if (name == "KartyGraficzneAdd")
                CreateView(new NowaKartaGraficznaViewModel());
            if (name == "ProcesoryAdd")
                CreateView(new NowyProcesorViewModel());
            if (name == "PamieciRAMAdd")
                CreateView(new NowaPamiecRAMViewModel());
            if (name == "DyskiAdd")
                CreateView(new NowyDyskViewModel());
            if (name == "PlytyGlowneAdd")
                CreateView(new NowaPlytaGlownaViewModel());
            if (name == "KlienciAdd")
                CreateView(new NowyKlientViewModel());
            if (name == "OsobyFizyczneAdd")
                CreateView(new NowaOsobaFizycznaViewModel());
            if (name == "FirmyAdd")
                CreateView(new NowaFirmaViewModel());
            if (name == "ZamowieniaAdd")
                CreateView(new NoweZamowienieViewModel());
            if (name == "PozycjeZamowieniaAdd")
                CreateView(new NowaPozycjaZamowieniaViewModel());
            if (name == "PracownicyAdd")
                CreateView(new NowyPracownikViewModel());

            if (name == "ProduktyAll")
                ShowAllProdukt();
            if (name == "ZamowieniaAll")
                ShowAllZamowienie();
            if (name == "PromocjeAll")
                ShowAllPromocja();
            if (name == "KlienciAll")
                ShowAllKlient();
        }
        #endregion
    }
}
