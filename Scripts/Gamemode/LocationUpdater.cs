using UnityEngine;
using System.Collections;
using System;

public class LocationUpdater : MonoBehaviour
{
    public float IntervalSeconds = 1.0f;
    public LocationServiceStatus Status;
    public LocationInfo Location;

    public Gamemanager GM;
    //経度
    double lat1, lat2;
    //緯度
    double lon1, lon2;

    double distance, distance_All, Distance60,Distance60minus;
    double speed, speed60;

    int timelog;

    bool Switch;

    private void Start()
    {
        Switch = false;
        timelog = 0;
        Distance60minus = 0;
        StartCoroutine("CheckLocation");
        StartCoroutine("CheckSpeed60");
    }


    private void Update()
    {
        Switch = GM.GetSwitch();

        timelog = GM.GetTime();

    }

    //GPS機能連動（使うときはアプリの位置機能を連動すること）
    IEnumerator CheckLocation()
    {
        while (true)
        {
            if(Switch == true)
            {
                this.Status = Input.location.status;
                if (Input.location.isEnabledByUser)
                {
                    switch (this.Status)
                    {
                        case LocationServiceStatus.Stopped:
                            Input.location.Start();
                            break;
                        case LocationServiceStatus.Running:
                            this.Location = Input.location.lastData;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // FIXME 位置情報を有効にして!! 的なダイアログの表示処理を入れると良さそう
                    Debug.Log("location is disabled by user");
                }

                if(lat1 == 0 && lon1 == 0)
                {
                    lat1 = Location.latitude;
                    lon1 = Location.longitude;
                }
                else
                {
                    lat1 = lat2;
                    lon1 = lon2;
                }

                lat2 = Location.latitude;
                lon2 = Location.longitude;

                distance_All += calcdistance(lat1, lon1, lat2, lon2);
                distance = calcdistance(lat1, lon1, lat2, lon2);
            }

            // 指定した秒数後に再度判定を走らせる
            yield return new WaitForSeconds(IntervalSeconds);
        }
    }

    IEnumerator CheckSpeed60()
    {
        while (true)
        {
            if(GM.GetSwitch() == true)
            {
                yield return new WaitForSeconds(60);
                //60秒ごとに60秒で進んだ距離を計算する
                //（60秒で進んだ距離）=（全距離）-（直近の60秒前まで進んだ距離）
                Distance60 = distance_All - Distance60minus;
                Distance60minus = distance_All;

                speed60 = Distance60 * 60;
                
            }
            else
            {
                yield return null;
            }
        }

    }

    //renderer輸送用
    public double GetdistanceAll()
    {
        return distance_All;
    }

    //renderer輸送用


    public double GetSpeed60()
    {
        return speed60;
    }

    //公式に従い距離を出す。doubleなのは桁数の問題
    double calcdistance(double lat1, double lon1, double lat2, double lon2)
    {
        double rad = Math.PI/180;

        double th = Math.Cos(lat1 * rad) * Math.Cos(lat2 * rad) * Math.Cos((lon2 - lon1) * rad) + Math.Sin(lat1 * rad) * Math.Sin(lat2 * rad);

        //NaN対策のClamp
        if(th > 1)
        {
            th = 1;
        }else if (th < -1)
        {
            th = -1;
        }

        double dist = 6371 * Math.Acos(th);
        return dist;
    }
}