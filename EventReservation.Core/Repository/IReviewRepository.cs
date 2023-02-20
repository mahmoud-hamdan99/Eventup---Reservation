﻿using EventReservation.Core.Data;
using EventReservation.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Core.Repository
{
   public interface IReviewRepository
    {
        List<Review> GetAllReviews();
        //Update Update()

        bool AddReview(Review review);

        AvgRateDTO GetAvgRate();
    }
}
