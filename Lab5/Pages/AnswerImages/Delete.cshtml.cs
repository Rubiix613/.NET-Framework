using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;
using Azure.Storage.Blobs;



namespace Lab5.Pages.AnswerImages
{
    
    public class DeleteModel : PageModel
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string earthContainerName = "earthimages";
        private readonly string computerContainerName = "computerimages";
        private readonly Lab5.Data.AnswerImageDbContext _context;

        public DeleteModel(Lab5.Data.AnswerImageDbContext context, BlobServiceClient blobServiceClient)
        {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        [BindProperty]
      public AnswerImage AnswerImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AnswerImage == null)
            {
                return NotFound();
            }

            var answerimage = await _context.AnswerImage.FirstOrDefaultAsync(m => m.AnswerImageId == id);

            if (answerimage == null)
            {
                return NotFound();
            }
            else 
            {
                AnswerImage = answerimage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AnswerImage == null)
            {
                return NotFound();
            }
            var answerimage = await _context.AnswerImage.FindAsync(id);

            if (answerimage != null)
            {
                AnswerImage = answerimage;
                _context.AnswerImage.Remove(AnswerImage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
