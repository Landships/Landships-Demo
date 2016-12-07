using UnityEngine;
using System.Collections;

public class AI_Controller_VR : MonoBehaviour {

    public int ai_id;
    byte current_player; // owner = 2

    GameObject n_manager;
    network_manager n_manager_script;
    Cannon_Fire_CS cannon_fire;

    bool started = false;
    bool ready = false;

    bool reliable_message = false;
    int client_player;

    int frame_interval = 5;

    // Use this for initialization
    void Start()
    {
    }

  

    public void Prep()
    {
        n_manager = GameObject.Find("Custom Network Manager(Clone)");
        n_manager_script = n_manager.GetComponent<network_manager>();
        current_player = (byte)(n_manager_script.client_players_amount);
        if (current_player != 2)
        {

        }
        BroadcastMessage("Set_Ai_Id", ai_id);
    }



    void Update()
    {

        if (n_manager != null)
        {
            started = n_manager_script.started;
            ready = n_manager_script.game_ready;

            client_player = n_manager_script.server_player_control;

            reliable_message = n_manager_script.reliable_message;

            if (current_player == 2)
            {
                
            }
            else {
                if (reliable_message)
                {
                    if (n_manager_script.server_read_client_reliable_buffer(2) == 1 && ai_id == 1)
                    {
                        transform.FindChild("Turret").GetComponent<Damage_Control_CS>().Penetration();
                    }
                    if (n_manager_script.server_read_client_reliable_buffer(3) == 1 && ai_id == 2)
                    {
                        transform.FindChild("Turret").GetComponent<Damage_Control_CS>().Penetration();
                    }
                    if (n_manager_script.server_read_client_reliable_buffer(4) == 1 && ai_id == 3)
                    {
                        transform.FindChild("Turret").GetComponent<Damage_Control_CS>().Penetration();
                    }
                    if (n_manager_script.server_read_client_reliable_buffer(5) == 1 && ai_id == 4)
                    {
                        transform.FindChild("Turret").GetComponent<Damage_Control_CS>().Penetration();
                    }
                }
            }


        }
    }


    public void Alert_Turret_Penetration(int id)
    {
        transform.FindChild("Turret").GetComponent<Damage_Control_CS>().Penetration();
        n_manager_script.send_reliable_from_client(ai_id + 1, 1);

    }



}
