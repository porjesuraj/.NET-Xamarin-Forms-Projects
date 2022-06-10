using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_ZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       readonly SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();
            // setting up connection string for database connection
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WPF_ZooManager.Properties.Settings.SurajTrainingDBConnectionString"].ConnectionString;

            sqlConnection = new SqlConnection(connectionString);
            ShowZoos();
            ShowAllAnimal();
            
        }


        private void ShowAllAnimal()
        {
            try
            {
                string query = "Select * from Animal";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable animalTable = new DataTable();

                    sqlDataAdapter.Fill(animalTable);

                    allAnimalList.DisplayMemberPath = "Name";
                    allAnimalList.SelectedValuePath = "Id";

                    allAnimalList.ItemsSource = animalTable.DefaultView;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
                
            }
            
        }


        private void ShowAnimal()
        {
            try
            {
                string query = "Select * from Animal a inner join ZooAnimal za on a.Id = za.AnimalId where za.ZooId = @Zooid";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);



                using(sqlDataAdapter)
                {
                    if (zooList.SelectedValue == null)
                        return; 
                    sqlCommand.Parameters.AddWithValue("@Zooid", zooList.SelectedValue);

                    DataTable animalTable = new DataTable();

                    sqlDataAdapter.Fill(animalTable);

                    animalList.DisplayMemberPath = "Name";
                    animalList.SelectedValuePath = "Id";

                    animalList.ItemsSource = animalTable.DefaultView;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }

            
        }

        private void ShowZoos()
        {
            try
            {
                string query = "select * from Zoo";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();

                    sqlDataAdapter.Fill(zooTable);

                    zooList.DisplayMemberPath = "Location";
                    zooList.SelectedValuePath = "Id";
                    zooList.ItemsSource = zooTable.DefaultView;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }
            
        }

        private void ZooList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            ShowAnimal();
            ShowSelectedZooInTextBox();
        }

        private void Zoo_Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Zoo where Id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", zooList.SelectedValue);

                sqlCommand.ExecuteScalar();

                
            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }

        }

        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(newZooTextBox.Text))
                {
                    MessageBox.Show("Please Enter Zoo Name");

                    return;

                }

                string query = "insert into  Zoo values(@Location)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", newZooTextBox.Text);

                sqlCommand.ExecuteScalar();


            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
                newZooTextBox.Text = null;
            }
        }

        private void AddNewAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                string query = "insert into  Animal values(@Animal)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Animal", associatedAnimalTextBox.Text);
               
                sqlCommand.ExecuteScalar();


            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                ShowAllAnimal();
                associatedAnimalTextBox.Text = null;
            }
        }


        private void AddAssociatedAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                string query = "insert into ZooAnimal values(@ZooId,  @AnimalId)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", allAnimalList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@ZooId", zooList.SelectedValue);

                sqlCommand.ExecuteScalar();


            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();


                ShowAnimal();
            }
        }

        private void RemoveAssociatedAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                string query = "delete from ZooAnimal where ZooId = @ZooId AND AnimalId = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", animalList.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@ZooId", zooList.SelectedValue);

                sqlCommand.ExecuteScalar();


            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
               

                ShowAnimal();
            }
        }

        private void UpdateAlldAnimalList_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                string query = "update  Animal Set Name= @Name where Id = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", associatedAnimalTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@AnimalId", allAnimalList.SelectedValue);


                sqlCommand.ExecuteScalar();


            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();


                ShowAllAnimal();
            }
        }

        private void DeleteAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                string query = "delete from Animal where Id = @AnimalId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", allAnimalList.SelectedValue);
              
                sqlCommand.ExecuteScalar();


            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();


                ShowAllAnimal();
            }
        }

        private void UpdateZooName_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                string query = "update  Zoo set Location= @Location where Id = @ZooId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", newZooTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@ZooId", zooList.SelectedValue);



                sqlCommand.ExecuteScalar();


            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();


                ShowZoos();
            }
        }
    
        private void ShowSelectedZooInTextBox()
        {
            try
            {
                string query = "Select Location from Zoo where Id = @Zooid";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);



                using (sqlDataAdapter)
                {
                    if (zooList.SelectedValue == null)
                        return;
                    sqlCommand.Parameters.AddWithValue("@Zooid", zooList.SelectedValue);

                    DataTable zooTable = new DataTable();

                    sqlDataAdapter.Fill(zooTable);

                    newZooTextBox.Text = zooTable.Rows[0]["Location"].ToString();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }


        }


        private void ShowSelectedAnimalInTextBox()
        {
            try
            {
                string query = "Select Name from Animal where Id = @Animalid";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);



                using (sqlDataAdapter)
                {

                    if (zooList.SelectedValue == null)
                        return;

                    if (allAnimalList.SelectedValue == null)
                        return;
                    sqlCommand.Parameters.AddWithValue("@Animalid", allAnimalList.SelectedValue);

                    DataTable animalTable = new DataTable();

                    sqlDataAdapter.Fill(animalTable);

                    associatedAnimalTextBox.Text = animalTable.Rows[0]["Name"].ToString();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("error message : " + ex.Message);
            }


        }
        private void AllAnimalList_ItemSelected(object sender, SelectionChangedEventArgs e)
        {


            ShowSelectedAnimalInTextBox();
        }
    }
}
