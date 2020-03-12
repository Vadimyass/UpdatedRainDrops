using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChankPlacer : MonoBehaviour
{
    public Transform player;
    public Chank[] ChanksCopy;
    public Chank FirstChank;
    private List<Chank> AddedChanks = new List<Chank>();

    private void Start()
    {
        AddedChanks.Add(FirstChank);
    }

    private void Spawner(){
        Chank newChank = Instantiate(ChanksCopy[Random.Range(0, ChanksCopy.Length)]);
       newChank.transform.position = AddedChanks[AddedChanks.Count - 1].End.position - newChank.Begin.localPosition;
       AddedChanks.Add(newChank);
       
       if(AddedChanks.Count > 3){
         Destroy(AddedChanks[0].gameObject);
           AddedChanks.RemoveAt(0);
       }
    }
    
    private void Update()
    {
        if(player.position.y < AddedChanks[AddedChanks.Count - 1].End.position.y +7 ){
            Spawner();
        }
    }
}
