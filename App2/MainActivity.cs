using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button add;
        EditText name, surname, age;
        TextView status;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);           
            SetContentView(Resource.Layout.activity_main);
            add = FindViewById<Button>(Resource.Id.button1);
            name = FindViewById<EditText>(Resource.Id.editText1);
            surname = FindViewById<EditText>(Resource.Id.editText2);
            age = FindViewById<EditText>(Resource.Id.editText3);
            status = FindViewById<TextView>(Resource.Id.textView5);            
            add.Click += Add_Click;            
        }

        private void Add_Click(object sender, System.EventArgs e)
        {
//@karakusnavy github
            MySqlConnection con = new MySqlConnection("Server=YOUR MYSQL HOST IP;Database=DATABASE NAME;Uid=DATABASE USER ID;Pwd=PASSWORD;");
            MySqlCommand cmd = new MySqlCommand("insert into users(name,surname,age) values('" + name.Text + "','"+surname.Text+"','"+age.Text+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            status.Text = "Succesfull !";
        }
    }
}