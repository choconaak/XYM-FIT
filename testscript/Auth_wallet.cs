using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using Symnity.Core.Crypto;
using Symnity.Http;
using Symnity.Model.Accounts;
using Symnity.Model.Network;
using Symnity.Model.Transactions;
using Symnity.Infrastructure;

public class Auth_wallet : MonoBehaviour
{
    public Text check;
    private TransactionRepository transactionRepository;

    public void checkstring()
    {
        transactionRepository = new TransactionRepository(setconst.node);
        StartCoroutine("Authcheck");
    }

    IEnumerator Authcheck()
    {
        string add1 = Wallet.GSwalletaddress[0].ToString();
        string add2 = Wallet.GSwalletaddress[1].ToString();
        string add39 = Wallet.GSwalletaddress[38].ToString();

        //1文字目のチェック
        bool check1 = Regex.IsMatch(add1, @"[N,T]");
        //2文字目のチェック
        bool check2 = Regex.IsMatch(add2, @"[A,B,C,D]");
        //末端のチェック
        bool check39 = Regex.IsMatch(add39, @"[A,I,Q,Y]");
        //鍵は現状こういう仕組みであることしかわからなかった
        bool checkkey = Regex.IsMatch(Wallet.GSkey, @"[A-F0-9]");

        if (Wallet.GSwalletaddress.Length == 39 && Wallet.GSkey.Length == 64 && check1 && check2 && check39 && checkkey)
        {
            //認証が成功したとき
            check.gameObject.SetActive(true);
            check.text = "Connected!";
            //マルチシグ登録
            multisig();
            //playerprefsにセーブ
            //PlayerPrefs.SetString("Walletaddress", Wallet.GSwalletaddress);
            //セキュリティの都合上暗号化しておきたい
            //var encryptedPrivateKey = Crypto.EncryptString(Wallet.GSkey, Wallet.GSwalletaddress);
            //PlayerPrefs.SetString("key", encryptedPrivateKey);
            yield return new WaitForSeconds(2);
            check.gameObject.SetActive(false);
            SceneManager.LoadScene("home");
        }
        else
        {
            check.gameObject.SetActive(true);
            check.text = "Wrong column";
            yield return new WaitForSeconds(2);
            check.gameObject.SetActive(false);
        }
    }

    private async void multisig()
    {
        //金庫側
        Account bob = Account.CreateFromPrivateKey(setconst.signerkey, setconst._networkType);
        //アカウント側
        Account carol = Account.CreateFromPrivateKey(Wallet.GSkey, setconst._networkType);

        var epocAdjustment = await HttpUtilities.GetEpochAdjustment(setconst.node);
        var generationHash = await HttpUtilities.GetGenerationHash(setconst.node);

        var multisigTx = MultisigAccountModificationTransaction.Create(
            Deadline.Create(epocAdjustment),
            1, //minApproval:承認のために必要な最小署名者数増分
            1, //minRemoval:除名のために必要な最小署名者数増分
            new List<UnresolvedAddress>()
            {
                carol.Address
            },//追加対象アドレスリスト
            new List<UnresolvedAddress>(),//除名対象アドレスリスト
            setconst._networkType
            );

        var aggregateTx = AggregateTransaction.CreateComplete(
                Deadline.Create(epocAdjustment),
                new List<Transaction>
                {
                    multisigTx.ToAggregate(bob.GetPublicAccount()),

                },
                setconst._networkType,
                new List<AggregateTransactionCosignature>()
                ).SetMaxFeeForAggregate(100, 2);

        var signedTx = aggregateTx.SignTransactionWithCosignatories(
                bob,
                new List<Account> { carol },
                generationHash
            );

        string result = await transactionRepository.Announce(signedTx);
        Debug.Log(result);
    }
}
