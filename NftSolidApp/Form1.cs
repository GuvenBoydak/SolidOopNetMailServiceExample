using NftSolidApp.Base;
using NftSolidApp.Commands;
using NftSolidApp.Entities;
using NftSolidApp.Enums;
using NftSolidApp.Factories;
using NftSolidApp.Handler;
using NftSolidApp.Query;
using NftSolidApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NftSolidApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void FillComboBox()
        {
            cmbProtocol.Text = string.Empty;
            cmbGender.Text = string.Empty;
            cmbHat.Text = string.Empty;
            cmbBackGround.Text = string.Empty;
            cmbState.Text = string.Empty;
            cmbSellStateChange.Text = string.Empty;
            cmbStateFilter.Text= string.Empty;
            cmbBuyStateChange.Text = string.Empty;
            cmbUser.Text = string.Empty;
            cmbUserFilter.Text = string.Empty;
            CmbUserBuying.Text = string.Empty;
            cmbNftNameFilter.Text = string.Empty;


            foreach (var item in Enum.GetValues(typeof(Protocol)))
            {
                cmbProtocol.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                cmbGender.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(Hat)))
            {
                cmbHat.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(Background)))
            {
                cmbBackGround.Items.Add(item);
            }

            foreach (var item in Enum.GetValues(typeof(NftState)))
            {
                cmbState.Items.Add(item);
                cmbSellStateChange.Items.Add(item);
                cmbStateFilter.Items.Add(item);
                cmbBuyStateChange.Items.Add(item);
            }

            UserRepository userRepository = UserRepositoryFactory.GetInstance();
            List<User> user = userRepository.GetAll();
            cmbUser.Items.AddRange(user.ToArray());
            cmbUserFilter.Items.AddRange(user.ToArray());
            CmbUserBuying.Items.AddRange(user.ToArray());


            NftRepository nftRepository = NftRepositoryFactory.GetInstance();
            List<Nft> nfts = nftRepository.GetAll();
            foreach (var item in nfts)
            {
                cmbNftNameFilter.Items.Add(item);
            }
        }
        void FillListView()
        {
            lstListNft.Items.Clear();


            NftRepository nftRepository = NftRepositoryFactory.GetInstance();
            List<Nft> nfts = nftRepository.GetAll();

            foreach (var item in nfts)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = item.NftName;
                lv.SubItems.Add(item.Description);
                lv.SubItems.Add(item.Gender);
                lv.SubItems.Add(item.Hat);
                lv.SubItems.Add(item.Background);
                if (item.Price != null)
                {
                    lv.SubItems.Add(item.Price.ToString());
                }
                else
                {
                    lv.SubItems.Add(item.Price.ToString());
                }
                lv.SubItems.Add(item.User.Name + " " + item.User.Surname);
                lv.SubItems.Add(item.State);
                lv.Tag = item;

                lstListNft.Items.Add(lv);
            }
        }
        void FillListNft(List<Nft> nftList)
        {
            lstListNft.Items.Clear();

            foreach (var item in nftList)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = item.NftName;
                lv.SubItems.Add(item.Description);
                lv.SubItems.Add(item.Gender);
                lv.SubItems.Add(item.Hat);
                lv.SubItems.Add(item.Background);
                if (item.Price != null)
                {
                    lv.SubItems.Add(item.Price.ToString());
                }
                else
                {
                    lv.SubItems.Add(item.Price.ToString());
                }
                lv.SubItems.Add(item.User.Name + " " + item.User.Surname);
                lv.SubItems.Add(item.State);
                lv.Tag = item;

                lstListNft.Items.Add(lv);
            }
        }
        void ClearControl()
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is TextBox)
                {
                    TextBox textBox = (TextBox)this.Controls[i];
                    textBox.Text = string.Empty;
                }
                else if (Controls[i] is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)this.Controls[i];
                    comboBox.Text = String.Empty;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FillComboBox();
            FillListView();
            ClearControl();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text;
            string surname = TxtUserSurname.Text;
            string email = txtEmail.Text;
            decimal wallet = decimal.Parse(txtUserWallet.Text);

            UserCreateCommand command = new UserCreateCommand(name, surname, email, wallet);
            UserCreateHandler handler = UserCreateHandlerFactory.GetInstance();
            ResponceBase responce = handler.Execute(command);
            MessageBox.Show(responce.Message);
            FillListView();
            ClearControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nftName = txtNftName.Text;
            string protocol = cmbProtocol.SelectedItem.ToString();
            string description = txtDesciription.Text;
            string gender = cmbGender.SelectedItem.ToString();
            string hat = cmbHat.SelectedItem.ToString();
            string background = cmbBackGround.SelectedItem.ToString();
            int UserId = ((User)cmbUser.SelectedItem).UserId;
            string state = cmbState.SelectedItem.ToString();
            decimal? price = null;
            if (state == NftState.OnTheSalesList.ToString())
            {
                try
                {
                    price = decimal.Parse(txtNftPrice.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Satış Fiyatini Eklemelisiniz.");
                    return;
                }

            }


            NftCreateCommand command = new NftCreateCommand(nftName, protocol, description, gender, hat, background, price, UserId, state);
            NftCreateHandler handler = NftCreateHandlerFactory.GetInstance();
            ResponceBase responce = handler.Execute(command);
            MessageBox.Show(responce.Message);


            FillListView();
            ClearControl();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (lstListNft.FocusedItem != null)
            {
                Nft selected_Nft = (Nft)lstListNft.FocusedItem.Tag;
                if (cmbSellStateChange.SelectedItem.ToString() == NftState.OnTheSalesList.ToString())
                {
                    try
                    {
                        selected_Nft.Price = decimal.Parse(txtPriceSell.Text);

                        NftOnTheSalesListCommand command = new NftOnTheSalesListCommand(selected_Nft.UserId, selected_Nft.Price, selected_Nft.NftId, selected_Nft.State);
                        NftOnTheSalesListHandler handler = NftOnTheSalesListHandlerFactory.GetInstance();
                        ResponceBase responce = handler.Execute(command);
                        MessageBox.Show(responce.Message);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("HATA Price Girmelisiniz!!!");
                    }
                }
                else if (cmbSellStateChange.SelectedItem.ToString() == NftState.NotOnSalesList.ToString())
                {
                    NftNotOnSalesListCommand command = new NftNotOnSalesListCommand(selected_Nft.UserId, selected_Nft.Price, selected_Nft.NftId, selected_Nft.State);
                    NftNotOnSalesListHandler handler = NftNotOnSalesListHandlerFactory.GetInstance();
                    ResponceBase responce = handler.Execute(command);
                    MessageBox.Show(responce.Message);
                }

                ClearControl();
                FillListView();
            }
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            Nft selectedNft = (Nft)lstListNft.FocusedItem.Tag;
            if (selectedNft != null)
            {
                if (cmbBuyStateChange.SelectedItem.ToString() == NftState.NotOnSalesList.ToString())
                {
                    int userId = ((User)CmbUserBuying.SelectedItem).UserId;
                    if (selectedNft.User.Wallet < selectedNft.Price)
                    {
                        MessageBox.Show("Bakiyeniz yetersiz HATA!!!");
                    }
                    else
                    {
                        NftBuyNotOnSalesListCommand command = new NftBuyNotOnSalesListCommand(userId, selectedNft.Price, selectedNft.NftId, selectedNft.State);
                        NftBuyNotOnSalesListHandler handler = NftBuyNotOnSalesListHandlerFactory.GetInstance();
                        ResponceBase responce = handler.Execute(command);
                        MessageBox.Show(responce.Message);
                    }
                }
                else if (cmbBuyStateChange.SelectedItem.ToString() == NftState.OnTheSalesList.ToString())
                {
                    User user = (User)CmbUserBuying.SelectedItem;
                    decimal? price = null;

                    if (user.Wallet < selectedNft.Price)
                    {
                        MessageBox.Show("Bakiyeniz yetersiz HATA!!!");
                    }
                    else
                    {
                        try
                        {
                            price = Convert.ToDecimal(txtPriceBuy.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("HATA Price Girmelisiniz!!!");
                            return;
                        }
                        NftBuyOnTheSalesListCommand command = new NftBuyOnTheSalesListCommand(user.UserId,price, selectedNft.NftId, selectedNft.State, user.Wallet);
                        NftBuyOnTheSalesListHandler handler = NftBuyOnTheSalesListHandlerFactory.GetInstance();
                        ResponceBase responce = handler.Execute(command);
                        MessageBox.Show(responce.Message);
                    }

                }
            }
            FillListView();
            ClearControl();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbNftNameFilter.SelectedItem != null)
            {
                Nft selectedNft = (Nft)cmbNftNameFilter.SelectedItem;
                GetNftNameQuery query = new GetNftNameQuery(selectedNft.NftId, selectedNft.NftName);
                GetNftNameQueryHandler handler = GetNftNameQueryHandlerFactory.GetInstance();
                List<Nft> nftList = handler.Execute(query);
                FillListNft(nftList);
            }
            else if (cmbUserFilter.SelectedItem != null)
            {
                User selectedUser = (User)cmbUserFilter.SelectedItem;
                GetUserQuery query = new GetUserQuery(selectedUser.UserId);
                GetUserQueryHandler handler = GetUserQueryHandlerFactory.GetInstance();
                List<Nft> userList = handler.Execute(query);
                FillListNft(userList);
            }
            else if (cmbStateFilter.SelectedItem != null)
            {
                string selectednft = cmbStateFilter.SelectedItem.ToString();

                GetNftStateQuery query = new GetNftStateQuery(selectednft);
                GetNftStateQueryHandler handler = GetNftStateQueryHandlerFactory.GetInstance();
                List<Nft> nftList = handler.Execute(query);
                FillListNft(nftList);
            }
            ClearControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nft selectedNft = (Nft)lstListNft.FocusedItem.Tag;

            NftDeleteCommand command = new NftDeleteCommand(selectedNft.NftId);
            NftDeleteHandler handler = NftDeleteHandlerFactory.GetInstance();
            ResponceBase responce = handler.Execute(command);
            MessageBox.Show(responce.Message);
            FillListView();
        }
    }
}
