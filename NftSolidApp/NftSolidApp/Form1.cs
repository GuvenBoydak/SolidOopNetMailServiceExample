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
                cmbStateChange.Items.Add(item);
                cmbStateFilter.Items.Add(item);
            }

            UserRepository userRepository = UserRepositoryFactory.GetInstance();
            List<User> user = userRepository.GetAll();
            cmbUser.Items.AddRange(user.ToArray());
            cmbUserFilter.Items.AddRange(user.ToArray());
            CmbUserBuying.Items.AddRange(user.ToArray());

            NftRepository nftRepository = NftRepositoryFactory.GetInstance();
            List<Nft> nfts = nftRepository.GetAll();
            cmbNftNameFilter.Items.AddRange(nfts.ToArray()); 
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
                if (item.Price!=null)
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
        void FillListView(List<Nft> nftList)
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
        private void Form1_Load(object sender, EventArgs e)
        {
            FillComboBox();
            FillListView();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text;
            string surname = TxtUserSurname.Text;
            string email = txtEmail.Text;

            UserCreateCommand command = new UserCreateCommand(name, surname, email);
            UserCreateHandler handler = UserCreateHandlerFactory.GetInstance();
            ResponceBase responce = handler.Execute(command);
            MessageBox.Show(responce.Message);
            FillListView();
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
            if (state==NftState.OnTheSalesList.ToString())
            {
                try
                {
                    price = decimal.Parse(txtNftPrice.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Satış Fiyatini Eklemelisiniz.");
                }                           
            }

            NftCreateCommand command = new NftCreateCommand(nftName, protocol, description, gender, hat, background, price, UserId, state);
            NftCreateHandler handler = NftCreateHandlerFactory.GetInstance();
            ResponceBase responce = handler.Execute(command);
            MessageBox.Show(responce.Message);
            FillListView();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (lstListNft.FocusedItem !=null)
            {
                Nft selected_Nft = (Nft)lstListNft.FocusedItem.Tag;
                if (selected_Nft.State == NftState.OnTheSalesList.ToString())
                {
                    try
                    {
                        selected_Nft.Price = decimal.Parse(txtNftPrice.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Satış Fiyatini Eklemelisiniz.");
                    }
                }

                NftOnTheSalesListCommand command = new NftOnTheSalesListCommand(selected_Nft.UserId,selected_Nft.Price,selected_Nft.NftId,selected_Nft.State);
                NftOnTheSalesListHandler handler = NftOnTheSalesListHandlerFactory.GetInstance();
                ResponceBase responce = handler.Execute(command);
                MessageBox.Show(responce.Message);
                FillListView();
            }
        }

        private void BtnBuy_Click(object sender, EventArgs e)
        {
            Nft selectedNft = (Nft)lstListNft.FocusedItem.Tag;
            if (selectedNft!=null)
            {
                if (selectedNft.State==NftState.NotOnSalesList.ToString())
                {
                    NftBuyNotOnSalesListCommand command = new NftBuyNotOnSalesListCommand(selectedNft.UserId,selectedNft.Price,selectedNft.NftId,selectedNft.State);
                    NftBuyNotOnSalesListHandler handler = NftBuyNotOnSalesListHandlerFactory.GetInstance();
                    ResponceBase responce = handler.Execute(command);
                    MessageBox.Show(responce.Message);
                }
            }
            else if (selectedNft.State == NftState.OnTheSalesList.ToString())
            {

            }
            FillListView();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cmbNftNameFilter.SelectedItem!=null)
            {
                Nft selectedNft = (Nft)cmbNftNameFilter.SelectedItem;
                GetNftNameQueryCommand query = new GetNftNameQueryCommand(selectedNft.NftId,selectedNft.NftName);
                GetNftNameQueryHandler handler = GetNftNameQueryHandlerFactory.GetInstance();
                List<Nft> nftList = handler.Execute(query);
                FillListView(nftList);
            }
        }
    }
}
