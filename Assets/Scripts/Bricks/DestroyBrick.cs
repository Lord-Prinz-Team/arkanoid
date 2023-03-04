using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour{
    int trueSilverHp = 2;  //1 + (level / 8)

    void removeLife(){
        trueSilverHp--;
    }   

    void OnCollisionEnter2D(Collision2D collision) {
        print(gameObject.name);
        if(gameObject.name.StartsWith("truewhite--brick")){
            removeLife();
            if(trueSilverHp == 0){
                ScoreSystem.instance.AddPoints(50); //50 * level
                Sound.instance.playDestroyedBrickSound();
                Destroy(gameObject);
            }
            else{
                Sound.instance.playBallBounceSound();
            }
        }

        else if(gameObject.name.StartsWith("truegold--brick")){
            Sound.instance.playGoldBlockHitSound();
        }

        else {
            Sound.instance.playDestroyedBrickSound();
            Destroy(gameObject);
        }
    }
}