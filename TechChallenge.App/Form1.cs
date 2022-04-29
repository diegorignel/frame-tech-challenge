using Newtonsoft.Json;
using System.Net;
using TechChallenge.Library.Entities.Response;
using TechChallenge.Library.Extensions;

namespace TechChallenge.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                int numberToCalculate;

                bool isValidNumber = int.TryParse(txtNumber.Text, out numberToCalculate);

                if (isValidNumber)
                {
                    if (numberToCalculate < 0)
                        MessageBox.Show("N�mero inv�lido. O n�mero deve ser inteiro e n�o negativo.");
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            string url = $"http://localhost:1000/api/get-divisors?number={numberToCalculate}";

                            HttpResponseMessage response = client.GetAsync(url).Result;

                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var content = response.Content.ReadAsStringAsync().Result;

                                List<DivisorResponse> divisors = content.ToList<DivisorResponse>();

                                var divisorsNumbers = divisors.Select(p => p.Number).ToList();
                                var primeNumbers = divisors.Where(p => p.IsPrime).Select(p => p.Number).ToList();

                                string entryNumberMessage = $"N�mero de Entrada: {numberToCalculate}";
                                string divisorsNumbersMessage = $"N�meros divisores: {string.Join(" ,", divisorsNumbers)}";
                                var primeNumberMessage = $"Divisores Primos: {string.Join(" ,", primeNumbers)}";

                                txtDetails.Clear();
                                txtDetails.Text = $"{entryNumberMessage}\n{divisorsNumbersMessage}\n{primeNumberMessage}";
                            }
                        }
                        txtNumber.Clear();
                        txtNumber.Focus();
                    }
                }
                else
                    MessageBox.Show("N�mero inv�lido. Preencha corretamente com um valor inteiro.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao calcular o n�mero indicado. Exce��o: {ex.Message}");
            }
        }
    }
}