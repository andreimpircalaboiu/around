using UnityEngine;
using Random = System.Random;

public enum Difficulty
{
    Easy = 1,
    Medium,
    Hard,
    VeryHard,
    Ultra
}
public class SatelliteFactory : MonoBehaviour
{

    private FormationManager Formation;
    private Random _rand;
    private int _number;
    private int _lastOne;
    public FormationManager Create(Difficulty dif)
    {

        _rand = new Random();
        switch ((int) dif)
        {
            case 1:
                _number = _rand.Next(6);
                break;
            case 2:
                _number = _rand.Next(10);
                break;
            case 3:
                _number = _rand.Next(1,10);
                break;
            case 4:
                _number = _rand.Next(10);
                break;
            case 5:
                _number = _rand.Next(10);
                break;
        }
    
                switch (_number)
                {
                    case 0: Formation = gameObject.AddComponent<XXOX>(); 
                        break;                                           
                    case 1: Formation = gameObject.AddComponent<XOXX>(); 
                        break;                                           
                    case 2: Formation = gameObject.AddComponent<OXOX>(); 
                        break;                                           
                    case 3: Formation = gameObject.AddComponent<XOXO>(); 
                        break;                                           
                    case 4: Formation = gameObject.AddComponent<XXOO>(); 
                        break;                                           
                    case 5: Formation = gameObject.AddComponent<OOXX>(); 
                        break;                                           
                    case 6: Formation = gameObject.AddComponent<OXOO>(); 
                        break;                                           
                    case 7: Formation = gameObject.AddComponent<OOXO>(); 
                        break;                                           
                    case 8: Formation = gameObject.AddComponent<XOOO>(); 
                        break;                                           
                    case 9: Formation = gameObject.AddComponent<OOOX>(); 
                        break;                                               
                }
    
        
        return Formation;
    }
}
