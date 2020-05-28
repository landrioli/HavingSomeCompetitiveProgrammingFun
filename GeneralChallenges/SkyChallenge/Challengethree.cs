using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralChallenges.SkyChallenge
{
    class Challengethree
    {
        //select p.id as id ,
        //       p.title as id ,
        //       COALESCE(SUM(r.number_of_tickets),0) as reserved_tickets
        //    from reservations as r
        //    full outer join Plays as p
        //    ON r.play_id = p.id
        //    GROUP BY p.id, p.title
        //    ORDER BY reserved_tickets desc
    }
}
