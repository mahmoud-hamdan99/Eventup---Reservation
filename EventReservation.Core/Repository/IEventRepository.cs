﻿using EventReservation.Core.Data;
using EventReservation.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Core.Repository
{
    public interface IEventRepository
    {
        List<EventInfoDTO> GetAllEvent();
        List<Event> GetAllAccepted();
        List<Event> GetAllRejected();
        bool AddNewEvent(EventToAddDto eventToAddDto);
        Event AcceptEvent(int EventId);
        Event RejectEvent(int EventId);
        bool DeleteEvent(int EventId);
       
        bool GetStatusOfHall(int Hallid, DateTime startAt, DateTime EndAt);
        //Event GetEventHall(int HallId);
        EventResultToDto GetEventById(int EventId);
       
       List<Event> SearchBetweenDate(DateTime startAt, DateTime EndAt);
        List<Event> GetEventByHall( int hallid);

        List<UserEventDto> GetEventByUserId(int userId);

    }
}
