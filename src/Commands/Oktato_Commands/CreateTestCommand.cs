using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Teszt__.src.DAL;
using Teszt__.src.Services;
using static Teszt__.src.DAL.Database;

namespace Teszt__.src.Commands.Oktato_Commands
{
    class CreateTestCommand : CommandBase
    {
        private Grid grid;
        private StackPanel mainStackPanel;
        private int _modelType;

        public CreateTestCommand(ref Grid grid, ref StackPanel mainStackPanel, ref int modelType)
        {
            this.grid = grid;
            this.mainStackPanel = mainStackPanel;
            _modelType = modelType;
        }

        public override void Execute(object parameter)
        {
            _modelType = 1;

            GridService.ClearGrid(ref grid, ref mainStackPanel);

            ColumnDefinition coldef1 = new ColumnDefinition();
            ColumnDefinition coldef2 = new ColumnDefinition();
            ColumnDefinition coldef3 = new ColumnDefinition();
            ColumnDefinition coldef4 = new ColumnDefinition();
            ColumnDefinition coldef5 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(coldef1);
            grid.ColumnDefinitions.Add(coldef2);
            grid.ColumnDefinitions.Add(coldef3);
            grid.ColumnDefinitions.Add(coldef4);
            grid.ColumnDefinitions.Add(coldef5);

            RowDefinition rowdef1 = new RowDefinition();
            RowDefinition rowdef2 = new RowDefinition();

            grid.RowDefinitions.Add(rowdef1);
            grid.RowDefinitions.Add(rowdef2);

            Label testName = new Label()
            {
                Content = "Teszt neve"
            };

            Grid.SetColumn(testName, 0);
            
            Grid.SetRow(testName, 0);

            Label questionsLabel = new Label()
            {
                Content = "Kérdés"
            };

            Label submitLimitLabel = new Label()
            {
                Content = "Kitölthetőségi szám"
            };

            Grid.SetColumn(submitLimitLabel, 1);

            Grid.SetRow(submitLimitLabel, 0);

            Label dateLabel = new Label()
            {
                Content = "Teszt időpontja"
            };

            Grid.SetColumn(dateLabel, 2);

            Grid.SetRow(dateLabel, 0);

            Label startTimeLabel = new Label()
            {
                Content = "Indítási idő (óra:perc)"
            };

            Grid.SetColumn(startTimeLabel, 3);

            Grid.SetRow(startTimeLabel, 0);

            Label endTimeLabel = new Label()
            {
                Content = "Kitölthető eddig (óra:perc)"
            };

            Grid.SetColumn(endTimeLabel, 4);

            Grid.SetRow(endTimeLabel, 0);

            TextBox testNameTb = new TextBox();

            Grid.SetColumn(testNameTb, 0);
            Grid.SetRow(testNameTb, 1);

            TextBox submitLimitTb = new TextBox();

            Grid.SetColumn(submitLimitTb, 1);
            Grid.SetRow(submitLimitTb, 1);

            DatePicker date = new DatePicker();

            Grid.SetColumn(date, 2);
            Grid.SetRow(date, 1);

            TextBox startTimeTb = new TextBox();

            Grid.SetColumn(startTimeTb, 3);
            Grid.SetRow(startTimeTb, 1);

            TextBox endTimeTb = new TextBox();

            Grid.SetColumn(endTimeTb, 4);
            Grid.SetRow(endTimeTb, 1);

            grid.Children.Add(testName);
            grid.Children.Add(submitLimitLabel);
            grid.Children.Add(dateLabel);
            grid.Children.Add(startTimeLabel);
            grid.Children.Add(endTimeLabel);

            grid.Children.Add(testNameTb);
            grid.Children.Add(submitLimitTb);
            grid.Children.Add(date);
            grid.Children.Add(startTimeTb);
            grid.Children.Add(endTimeTb);

            mainStackPanel.Children.Add(grid);

        }
    }
}
