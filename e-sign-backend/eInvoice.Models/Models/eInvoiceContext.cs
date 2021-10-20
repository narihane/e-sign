using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class eInvoiceContext : DbContext
    {
        public eInvoiceContext()
        {
        }

        public eInvoiceContext(DbContextOptions<eInvoiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CodeTemplate> CodeTemplates { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Issuer> Issuers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Receiver> Receivers { get; set; }
        public virtual DbSet<Signature> Signatures { get; set; }
        public virtual DbSet<SubmittedDoc> SubmittedDocs { get; set; }
        public virtual DbSet<TaxType> TaxTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Usersdetail> Usersdetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=eInvoice;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CodeTemplate>(entity =>
            {
                entity.ToTable("CodeTemplates", "business");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.FileType)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

           

            var CodeUsageBulkTemplateBytes = Convert.FromBase64String("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");


            modelBuilder.Entity<CodeTemplate>().HasData(new CodeTemplate { Id = Guid.Parse("72aa05d8-47fc-4558-b7f6-bcbafd0de450"), FileName = "CodeUsageBulkTemplate.xlsx", FileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", File = CodeUsageBulkTemplateBytes });

            var NewCodeBulkTemplateBytes = Convert.FromBase64String("UEsDBBQABgAIAAAAIQA3Mb2RewEAAIQFAAATAAgCW0NvbnRlbnRfVHlwZXNdLnhtbCCiBAIooAACAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACsVEtvwjAMvk/af6hynWhgh2maKBz2OG5IsB8QGreNaJMoNgz+/dzw0DQBFYJLoybx97AdD8frpk5WENA4m4lB2hcJ2NxpY8tMfM8+es8iQVJWq9pZyMQGUIxH93fD2cYDJhxtMRMVkX+REvMKGoWp82D5pHChUcS/oZRe5QtVgnzs959k7iyBpR61GGI0fINCLWtK3te8vVUyN1Ykr9t7LVUmlPe1yRWxULmy+h9JzxWFyUG7fNkwdIo+gNJYAVBTpz4YZgxTIGJjKORRzgA1Xka6c5VyZBSGlfH4wNZPMLQnp13t4r64HMFoSCYq0Kdq2Ltc1/LHhcXcuUV6HuTS1MQUpY0ydq/7DH+8jDIugxsLaf1F4A4dxD0GMn6vlxBhOgiRNjXgrdMeQbuYKxVAT4m7t7y5gL/YXSlXc86ApHa5ddkj6Dl+ftKT4Dzy1AhweRX2T7SN7nkGgkAGDo/0WLMfGHnkXF12aGeaBn2EW8YZOvoFAAD//wMAUEsDBBQABgAIAAAAIQC1VTAj9AAAAEwCAAALAAgCX3JlbHMvLnJlbHMgogQCKKAAAgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAArJJNT8MwDIbvSPyHyPfV3ZAQQkt3QUi7IVR+gEncD7WNoyQb3b8nHBBUGoMDR3+9fvzK2908jerIIfbiNKyLEhQ7I7Z3rYaX+nF1ByomcpZGcazhxBF21fXV9plHSnkodr2PKqu4qKFLyd8jRtPxRLEQzy5XGgkTpRyGFj2ZgVrGTVneYviuAdVCU+2thrC3N6Dqk8+bf9eWpukNP4g5TOzSmRXIc2Jn2a58yGwh9fkaVVNoOWmwYp5yOiJ5X2RswPNEm78T/XwtTpzIUiI0Evgyz0fHJaD1f1q0NPHLnXnENwnDq8jwyYKLH6jeAQAA//8DAFBLAwQUAAYACAAAACEA1Hdnti0DAABWBwAADwAAAHhsL3dvcmtib29rLnhtbKxVUW+bMBB+n7T/wLxnCiYEGlRStQnVInVT1XXrC1LlGKdYBZvZpkk07b/vDKFt2peuHUpsjoPP3919Zx8db+rKuWdKcylShA985DBBZcHFbYp+XJ25h8jRhoiCVFKwFG2ZRsfTjx+O1lLdLaW8cwBA6BSVxjSJ52lasproA9kwAZ6VVDUxYKpbTzeKkUKXjJm68gLfj7yacIF6hES9BkOuVpyyuaRtzYTpQRSriAH6uuSNHtBq+hq4mqi7tnGprBuAWPKKm20HipyaJotbIRVZVhD2Bo+djYJfBH/swxAMK4HrxVI1p0pquTIHAO31pF/Ej30P470UbF7m4HVIoafYPbc1fGClojeyih6wokcw7L8bDYO0Oq0kkLw3oo0fuAVoerTiFfvZS9chTfON1LZSFXIqok1WcMOKFMVgyjV7fABRqbY5bXkF3mA08THypg9yvlBgQO1PKsOUIIbNpDAgtR3198qqw56VEkTsXLJfLVcMegckBOHASGhClvqCmNJpVZWiWZL/0BBhLg40qbe5lq2iLFeskTpfiHvAgUY9aRod7Zu5VjS/ZkvryvnwottIZUiVN+2y4jS/YnUDrcN0/kTL5GXj/IOaCbXJ9CCBfZD9/fNkQqwqGRR7YZQD94v5OVTtO7mHGoJSil2LL6BIeHQjqErwze84i2dZNIld7Gcnbjibj93DGJ/BXTybZEGQhSH+A8GoKKGStKbcycNCpyi0gn7u+ko2gwf7ScuLRxq//d3l2vnZMPj+2IDtRviTs7V+FJI1nc01F4Vcp8jFAQS13TfXnfOaF6YEJfrxCF7pn31h/LYExhjjyLaNCiyzFO0xmveMzuBy7bDHyHtCqdtygVo3O6JrkzkxJBNGbWF7tztyl2fojMQuoxZF1xTe8GXBVlywwnYY4DyxdmgzWbCrbQNnw/TzZXb26ch78g5oYP97Sip6oRw7dctGwQSPbBrZxpxr082gfw7x4tA/if1J6PrZaOyGh5PAPQxHgTsL50E2jrN5djq2BbdnUPI/duKuDZPhcLMsS6LMlSL0Djrtkq1OiQaF9ukBvhDcwNobvpr+BQAA//8DAFBLAwQUAAYACAAAACEAgT6Ul/MAAAC6AgAAGgAIAXhsL19yZWxzL3dvcmtib29rLnhtbC5yZWxzIKIEASigAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAArFJNS8QwEL0L/ocwd5t2FRHZdC8i7FXrDwjJtCnbJiEzfvTfGyq6XVjWSy8Db4Z5783Hdvc1DuIDE/XBK6iKEgR6E2zvOwVvzfPNAwhi7a0egkcFExLs6uur7QsOmnMTuT6SyCyeFDjm+CglGYejpiJE9LnShjRqzjB1Mmpz0B3KTVney7TkgPqEU+ytgrS3tyCaKWbl/7lD2/YGn4J5H9HzGQlJPA15ANHo1CEr+MFF9gjyvPxmTXnOa8Gj+gzlHKtLHqo1PXyGdCCHyEcffymSc+WimbtV7+F0QvvKKb/b8izL9O9m5MnH1d8AAAD//wMAUEsDBBQABgAIAAAAIQCGwNtSXAMAAIMJAAAYAAAAeGwvd29ya3NoZWV0cy9zaGVldDEueG1snFbbbtswDH0fsH8w9F7b8iVpgjhF1zZtCgwo1l2eFVlJhNqWJylJi2H/Pkq+JHa2Lm2RmrJJHh6RFO3JxXOeOVsmFRdFgrDrI4cVVKS8WCXo29fZ2TlylCZFSjJRsAS9MIUuph8/THZCPqk1Y9oBhEIlaK11OfY8RdcsJ8oVJStAsxQyJxpu5cpTpWQktU555gW+P/BywgtUIYzlKRhiueSUXQu6yVmhKxDJMqKBv1rzUjVoOT0FLifyaVOeUZGXALHgGdcvFhQ5OR3PV4WQZJHBvp9xRKjzLOEXwH/YhLHPjyLlnEqhxFK7gOxVnI+3P/JGHqEt0vH+T4LBkSfZlpsC7qGC91HCcYsV7MHCd4INWjCTLjne8DRBv/z67wwkNhd/f2l0v9F0knKosNmVI9kyQZd4fB8gbzqx/fOds506WDuaLB5ZxqhmEAMjx7TnQognYziHRz4gKmtgEAnVfMuuWJYl6B6s1U8bA5YQwGsjHK6baDPb0A/SSdmSbDL9RezuGF+tNYSNYZumT8bpyzVTFBoUArtBbFCpyAACrk7OzUmDBiPPFVWe6jWsIneI/VE4BBS6UVrkP2pF7V45Ql2sI8hdrcduFMTDcwyBnAVTesYNmVdRoCAWBWSDErjx0A/fAhLVICAbkPjNIMDZMgFZg0TBSYkY1I4ga8cwOEjEKykc1p4gG0//NE8YhpYsyNozGJxEdlQ7gtzvEkf+wNTsFaoY5nHVJ7BoyA7c4DzG8T98varTbBNfE02mEyl2DgwX0+clMaMajw3u31sVetQYX4I1dJGCY7Od+hNvC2eB1rpPh7qgq7s61IVd3fWhLurqbgw7y7GNGnctZscWg67F7bHFsGtxd2xx3rWYH1vgHlU7MLpU8X6nHmS7TTkc0jekHKzbzeNeyg1SgkJbjp7u6tBv1Et5B7NXx5uOsoc66yh7Vb6t6ASWThQFw14W7/6jn1eeOAj7ua0UYRTva1tltJrKVUOXZMU+E7nihXIytrRTFg6zrMaw78Jai9LMXjNMF0LDMG3u1vAJwqDBfRdm31II3dzAjDa4j0xvSkdIDtPbflUkqBRSS8I1RBibV5icp/ZFAe+cjD0QqZVDxcYMewwJaZ/ure17y9ubw1lqP5+mfwAAAP//AwBQSwMEFAAGAAgAAAAhAHU+mWmTBgAAjBoAABMAAAB4bC90aGVtZS90aGVtZTEueG1s7Flbi9tGFH4v9D8IvTu+SbK9xBts2U7a7CYh66TkcWyPrcmONEYz3o0JgZI89aVQSEtfCn3rQykNNNDQl/6YhYQ2/RE9M5KtmfU4m8umtCVrWKTRd858c87RNxddvHQvps4RTjlhSdutXqi4Dk7GbEKSWdu9NRyUmq7DBUomiLIEt90l5u6l3Y8/uoh2RIRj7IB9wndQ242EmO+Uy3wMzYhfYHOcwLMpS2Mk4DadlScpOga/MS3XKpWgHCOSuE6CYnB7fTolY+wMpUt3d+W8T+E2EVw2jGl6IF1jw0JhJ4dVieBLHtLUOUK07UI/E3Y8xPeE61DEBTxouxX155Z3L5bRTm5ExRZbzW6g/nK73GByWFN9prPRulPP872gs/avAFRs4vqNftAP1v4UAI3HMNKMi+7T77a6PT/HaqDs0uK71+jVqwZe81/f4Nzx5c/AK1Dm39vADwYhRNHAK1CG9y0xadRCz8ArUIYPNvCNSqfnNQy8AkWUJIcb6Iof1MPVaNeQKaNXrPCW7w0atdx5gYJqWFeX7GLKErGt1mJ0l6UDAEggRYIkjljO8RSNoYpDRMkoJc4emUVQeHOUMA7NlVplUKnDf/nz1JWKCNrBSLOWvIAJ32iSfBw+TslctN1PwaurQZ4/e3by8OnJw19PHj06efhz3rdyZdhdQclMt3v5w1d/ffe58+cv3798/HXW9Wk81/EvfvrixW+/v8o9jLgIxfNvnrx4+uT5t1/+8eNji/dOikY6fEhizJ1r+Ni5yWIYoIU/HqVvZjGMEDEsUAS+La77IjKA15aI2nBdbIbwdgoqYwNeXtw1uB5E6UIQS89Xo9gA7jNGuyy1BuCq7EuL8HCRzOydpwsddxOhI1vfIUqMBPcXc5BXYnMZRtigeYOiRKAZTrBw5DN2iLFldHcIMeK6T8Yp42wqnDvE6SJiDcmQjIxCKoyukBjysrQRhFQbsdm/7XQZtY26h49MJLwWiFrIDzE1wngZLQSKbS6HKKZ6wPeQiGwkD5bpWMf1uYBMzzBlTn+CObfZXE9hvFrSr4LC2NO+T5exiUwFObT53EOM6cgeOwwjFM+tnEkS6dhP+CGUKHJuMGGD7zPzDZH3kAeUbE33bYKNdJ8tBLdAXHVKRYHIJ4vUksvLmJnv45JOEVYqA9pvSHpMkjP1/ZSy+/+Msts1+hw03e74XdS8kxLrO3XllIZvw/0HlbuHFskNDC/L5sz1Qbg/CLf7vxfube/y+ct1odAg3sVaXa3c460L9ymh9EAsKd7jau3OYV6aDKBRbSrUznK9kZtHcJlvEwzcLEXKxkmZ+IyI6CBCc1jgV9U2dMZz1zPuzBmHdb9qVhtifMq32j0s4n02yfar1arcm2biwZEo2iv+uh32GiJDB41iD7Z2r3a1M7VXXhGQtm9CQuvMJFG3kGisGiELryKhRnYuLFoWFk3pfpWqVRbXoQBq66zAwsmB5Vbb9b3sHAC2VIjiicxTdiSwyq5MzrlmelswqV4BsIpYVUCR6ZbkunV4cnRZqb1Gpg0SWrmZJLQyjNAE59WpH5ycZ65bRUoNejIUq7ehoNFovo9cSxE5pQ000ZWCJs5x2w3qPpyNjdG87U5h3w+X8Rxqh8sFL6IzODwbizR74d9GWeYpFz3EoyzgSnQyNYiJwKlDSdx25fDX1UATpSGKW7UGgvCvJdcCWfm3kYOkm0nG0ykeCz3tWouMdHYLCp9phfWpMn97sLRkC0j3QTQ5dkZ0kd5EUGJ+oyoDOCEcjn+qWTQnBM4z10JW1N+piSmXXf1AUdVQ1o7oPEL5jKKLeQZXIrqmo+7WMdDu8jFDQDdDOJrJCfadZ92zp2oZOU00iznTUBU5a9rF9P1N8hqrYhI1WGXSrbYNvNC61krroFCts8QZs+5rTAgataIzg5pkvCnDUrPzVpPaOS4ItEgEW+K2niOskXjbmR/sTletnCBW60pV+OrDh/5tgo3ugnj04BR4QQVXqYQvDymCRV92jpzJBrwi90S+RoQrZ5GStnu/4ne8sOaHpUrT75e8ulcpNf1OvdTx/Xq171crvW7tAUwsIoqrfvbRZQAHUXSZf3pR7RufX+LVWduFMYvLTH1eKSvi6vNLtbb984tDQHTuB7VBq97qBqVWvTMoeb1us9QKg26pF4SN3qAX+s3W4IHrHCmw16mHXtBvloJqGJa8oCLpN1ulhlerdbxGp9n3Og/yZQyMPJOPPBYQXsVr928AAAD//wMAUEsDBBQABgAIAAAAIQATATBNRQMAAFkIAAANAAAAeGwvc3R5bGVzLnhtbKxWTW/bOBC9L9D/IPCuUJIl1zYktXUcAQW6wQJJgV5pibKJ8kMg6ay8i/73DinZVtK0203rg00OOW/ezDySzt/0ggcPVBumZIHiqwgFVNaqYXJXoI/3VbhAgbFENoQrSQt0pAa9KV/9kRt75PRuT6kNAEKaAu2t7VYYm3pPBTFXqqMSVlqlBbEw1TtsOk1JY5yT4DiJojkWhEk0IKxE/TMggujPhy6sleiIZVvGmT16LBSIevV+J5UmWw5U+zglddDHc50EvT4F8dZv4ghWa2VUa68AF6u2ZTX9lu4SLzGpL0iA/DKkOMNR8ij3Xr8QKcWaPjDXPlTmrZLWBLU6SFugBIi6Eqw+S/W3rNwSdHjcVebmn+CBcLDECJd5rbjSgYXWQeW8RRJBhx3XhLOtZm5bSwTjx8GceL890QY0MEC9XjibV8DoKxj0wxmx4zYwfD623m0LVI0f5zEhoKRRnJinDGYTYI9vIADjfFKCwVDmoBVLtaxgNRjH98cOcpUg6wEGlv5z906TY5xkEwfsA5b5VukGjtGp+K7Og6nMOW0t5KPZbu9+rerge6usBamVecPITknCXY1OHuMA0qkp53fuqH1qH2H3bSAPohL2fVMgOLSuuqchJDIOB7xh4vCnaAP2BDYFyv8fNujbM/73vGPg9zyps3dAuo4fnUid/IbZO852UtDBVOagwmHq7ivLaifeGlbpoK++fUI/Tn+mLE8Y3B7ElurKX1rjQXiUVbr8PaC+FVD8SYcf9ffcqcAdgwLdOkYcTvRY7WB7YNwy+UxvAbPpL2pJoK0wh/Pk9TKRTexzcdfztWoghsANPsLHq9u7PO8383q7+L29OGAXGSTubmAv23NS4NPQlhy4vT8vFugy/pM27CDgzhp3/cUelPUQBbqMP7gzFM9dQNrbDwZuFPgNDpoV6N+b9evl5qZKwkW0XoTpjGbhMltvwiy9Xm821TJKousvk3fgF14B/2yB3uJ0ZTi8FXpMdiR/d7EVaDIZ6PtyAe0p92Uyj95lcRRWsygO0zlZhIv5LAurLE4283R9k1XZhHv2wtciwnE8vDuOfLayTFDO5KlXpw5NrdAkmP4gCXzqBL78Jyi/AgAA//8DAFBLAwQUAAYACAAAACEAP1qngvwAAAASAgAAFAAAAHhsL3NoYXJlZFN0cmluZ3MueG1sfJHRSsMwFIbvBd8h5N6lDhSRNGNUNwQR0foAITmuwSapOafDvb0pA4WsepnvP19y+CNXX75ne0joYqj55aLiDIKJ1oVdzd/azcUNZ0g6WN3HADU/APKVOj+TiMSyG7DmHdFwKwSaDrzGRRwg5OQ9Jq8pH9NO4JBAW+wAyPdiWVXXwmsXODNxDJTfveJsDO5zhOYHKIlOSVJNtNAeBpCClBQTO/L77WuJHgj8NF7yiT1p/ydfrlOp3AGa5AbKtfwTnXprQ24PmxR9qR2TNpY8zCw2MaZPlrKApZ2RmZnM5bxArwnsXB/b52aq6tGFD7C/N4r8p+obAAD//wMAUEsDBBQABgAIAAAAIQBBv/hg2QAAAMoBAAAjAAAAeGwvd29ya3NoZWV0cy9fcmVscy9zaGVldDEueG1sLnJlbHOskcFOwzAMQO9I/EPkO0m7A0Jo6S4IaVcYH+ClbhvROlFsEPt7gnah0yQunCzb8vOTvd19LbP5pCIxsYfWNmCIQ+ojjx7eDs93D2BEkXucE5OHEwnsutub7QvNqHVIppjFVAqLh0k1PzonYaIFxaZMXDtDKgtqTcvoMoZ3HMltmubeld8M6FZMs+89lH2/AXM45br5b3YahhjoKYWPhVivrHCKx5kqEMtI6sHac0XOobVVFtx1j/Y/PXKJrFReSbUeWlZGFz13kbf2GPlH0q0+0H0DAAD//wMAUEsDBBQABgAIAAAAIQDP4Ee0wgEAACwVAAAnAAAAeGwvcHJpbnRlclNldHRpbmdzL3ByaW50ZXJTZXR0aW5nczEuYmlu7FTNStxQGD0zse3opg4U3HRRpCtx6AyTqd1VmaR2StKEJDO4cTF0UgiMyZBERKWC+Bo+SJcuXfYBunYhxQdwo+emM9iWoYzgRvju5bvfzz05N/eQfDYifEGKBBntK3K8gss8QlzEOauqYuADpo3SnPb0J9wX2psS1LxcSCoD+ufYKpfpt8oaVwsh2XKu6VSW+xVLY7jyZZryNxybHV//k8nofO4u4xyvtdXq++3Do/+d8qTYnC+4HuAVheIRKjD5rmZ59XOCfDv4pLCL+I5D1PEOOv+SOhpcN1CDibdoslajGVjjrBHTZN1kVGeuM2/Qt5k10Sqyb2T0TN+wLHTjKA0zFbn9UZj60UEIywwC04OTRmGc9/MoieE6XuBtdAJ4YZYMd4saQ2ekogbayTBJ7WQQ/o7+vt1qFejphj25++nCaPklIb9oGu265FT0iz375OrZx6Wz1vEP1qzxHip3XAqr8pWxV/k6rafyRfD+CfvMLnbYA1Rn6bLfqG7gos8owx73UwwI/hfpcC+eEdsmxz5G5Pf5hDpPdbKcNRmigCggCogCooAoIAqIAqKAKCAKiAKigCggCsyiwC0AAAD//wMAUEsDBBQABgAIAAAAIQCfbPFVNAIAAHYGAAAUAAAAeGwvdGFibGVzL3RhYmxlMS54bWyclW1v2jAQx99P2neI/B6SwEQLIlQMRsXUTVPLPoCbXMBqbEf2hYKmfvedHcp4SKVofhHgHP/uf74Hxnc7WQRbMFZolbC4G7EAVKozodYJ+71adG5ZYJGrjBdaQcL2YNnd5POnMfLnAgI6rWzCNojlKAxtugHJbVeXoGgn10ZypJ9mHdrSAM/sBgBlEfaiaBBKLhSrCSOZtoFIbl6qspNqWXIUz6IQuPcsFsh0tFwrbZyqhO1MsDP9d/jOXMGlSI22OscuwUKd5yKFK43xl9DAVrir+Yfq/ydrcGSRLpElrEdMM6rc1z/RYXXoc+YeUWdByz/e995YoLik4FYuRjqdCVsWfP/zzGggT9g0Hn2nF1AjL+yjfn3a6FfKbsQmY16hXogCwQSnrzYqGdZKopjkeBWUNrfeWDip8z/TRSWVDVJdKaTycR58YdQbPs7Yxdm/DjSuoQcfjkt+avwh0JnOYLUv4cKdp7rktqP2L6hLBOnIdIEc+XyXLykDcZOPuL30rw3SXWIasdRjLbVPP8D2pqaJPGwNHl6A52BTI0p0pX6eXH/bNARaKr79GNys+aY1+uYCPU1RbGFhtDxLZdQUwKC1l0Gjl5VuovoWblXax845lPb9r5mrwwehXiBrLJL2BT6/UPzt/ukRCo6Q+TKndIYnPWkPHfqE+wKWKtenU8Ubf0AmKkmxWRobC2Es1t3sBoi3PfArkxsySAUE9GdAXeNO1oeOVp+WWsjkLwAAAP//AwBQSwMEFAAGAAgAAAAhAETHCVdRAQAAZwIAABEACAFkb2NQcm9wcy9jb3JlLnhtbCCiBAEooAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAISSUU+DMBSF3038D6TvUApotAGWqNmTMyZjmfGtae82Ii2krTL+vQU2ZNHEx/ac+/Wcm6aLo6y8L9CmrFWGSBAiDxSvRan2GdoUS/8OecYyJVhVK8hQBwYt8uurlDeU1xpedd2AtiUYz5GUobzJ0MHahmJs+AEkM4FzKCfuai2ZdUe9xw3jH2wPOArDWyzBMsEswz3QbyYiOiEFn5DNp64GgOAYKpCgrMEkIPjHa0FL8+fAoMycsrRd4zqd4s7Zgo/i5D6acjK2bRu08RDD5Sf4bfW8Hqr6pep3xQHlqeCUa2C21vm2VKJujbcxoFM8E/olVszYldv3rgTx0OUvbrzz1kx2Kf6tOupQYkSD8FwsOpY4K9v48alYojwKI+KHsU9IQRIa3dH45r1//GK+jzleyFOEf4mJT5IivKdxREkyI54B+ZD78mvk3wAAAP//AwBQSwMEFAAGAAgAAAAhAF1ihoORAQAAGgMAABAACAFkb2NQcm9wcy9hcHAueG1sIKIEASigAAEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAnJJNT+MwEIbvK+1/iHynTtkVWlWOESpFHBZRqYE9e51JY+HYlj1EDb+eSaKWFPa0t/l49fqZ8YjrQ2uzDmIy3hVsuchZBk77yrh9wZ7Ku4tfLEuoXKWsd1CwHhK7lt+/iW30ASIaSBlZuFSwBjGsOE+6gValBbUddWofW4WUxj33dW003Hr92oJDfpnnVxwOCK6C6iKcDNnkuOrwf00rrwe+9Fz2gYCluAnBGq2QppQPRkeffI3Z5qDBCj5vCqLbgX6NBnuZCz5PxU4rC2sylrWyCQT/KIh7UMPStsrEJEWHqw40+pgl80Zru2TZX5VgwClYp6JRDglrkE3JGNuQMMo/Pr6kBgCT4CSYimM4185j81MuRwEF58LBYAKhxjliadBCeqy3KuI/iJdz4pFh4p1wbhWqjcPYf0Ecp6bHPtmvfRuU62W5ebh53Al+zMVv417SUyg9WcJxr+dFsWtUhIq+4rT3U0Hc00qjHUzWjXJ7qI6ar43hCp6nU5fLq0X+I6cPntUE/zhq+Q4AAP//AwBQSwECLQAUAAYACAAAACEANzG9kXsBAACEBQAAEwAAAAAAAAAAAAAAAAAAAAAAW0NvbnRlbnRfVHlwZXNdLnhtbFBLAQItABQABgAIAAAAIQC1VTAj9AAAAEwCAAALAAAAAAAAAAAAAAAAALQDAABfcmVscy8ucmVsc1BLAQItABQABgAIAAAAIQDUd2e2LQMAAFYHAAAPAAAAAAAAAAAAAAAAANkGAAB4bC93b3JrYm9vay54bWxQSwECLQAUAAYACAAAACEAgT6Ul/MAAAC6AgAAGgAAAAAAAAAAAAAAAAAzCgAAeGwvX3JlbHMvd29ya2Jvb2sueG1sLnJlbHNQSwECLQAUAAYACAAAACEAhsDbUlwDAACDCQAAGAAAAAAAAAAAAAAAAABmDAAAeGwvd29ya3NoZWV0cy9zaGVldDEueG1sUEsBAi0AFAAGAAgAAAAhAHU+mWmTBgAAjBoAABMAAAAAAAAAAAAAAAAA+A8AAHhsL3RoZW1lL3RoZW1lMS54bWxQSwECLQAUAAYACAAAACEAEwEwTUUDAABZCAAADQAAAAAAAAAAAAAAAAC8FgAAeGwvc3R5bGVzLnhtbFBLAQItABQABgAIAAAAIQA/WqeC/AAAABICAAAUAAAAAAAAAAAAAAAAACwaAAB4bC9zaGFyZWRTdHJpbmdzLnhtbFBLAQItABQABgAIAAAAIQBBv/hg2QAAAMoBAAAjAAAAAAAAAAAAAAAAAFobAAB4bC93b3Jrc2hlZXRzL19yZWxzL3NoZWV0MS54bWwucmVsc1BLAQItABQABgAIAAAAIQDP4Ee0wgEAACwVAAAnAAAAAAAAAAAAAAAAAHQcAAB4bC9wcmludGVyU2V0dGluZ3MvcHJpbnRlclNldHRpbmdzMS5iaW5QSwECLQAUAAYACAAAACEAn2zxVTQCAAB2BgAAFAAAAAAAAAAAAAAAAAB7HgAAeGwvdGFibGVzL3RhYmxlMS54bWxQSwECLQAUAAYACAAAACEARMcJV1EBAABnAgAAEQAAAAAAAAAAAAAAAADhIAAAZG9jUHJvcHMvY29yZS54bWxQSwECLQAUAAYACAAAACEAXWKGg5EBAAAaAwAAEAAAAAAAAAAAAAAAAABpIwAAZG9jUHJvcHMvYXBwLnhtbFBLBQYAAAAADQANAGgDAAAwJgAAAAA=");

            modelBuilder.Entity<CodeTemplate>().HasData(new CodeTemplate { Id = Guid.Parse("fd7b397f-dada-4e08-adc4-861a62f97db9"), FileName = "NewCodeBulkTemplate.xlsx", FileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", File = NewCodeBulkTemplateBytes });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.ToTable("Delivery", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Approach)
                    .HasMaxLength(255)
                    .HasColumnName("approach");

                entity.Property(e => e.CountryOfOrigin)
                    .HasMaxLength(255)
                    .HasColumnName("countryOfOrigin");

                entity.Property(e => e.DateValidity)
                    .HasMaxLength(255)
                    .HasColumnName("dateValidity");

                entity.Property(e => e.ExportPort)
                    .HasMaxLength(255)
                    .HasColumnName("exportPort");

                entity.Property(e => e.GrossWeight)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("grossWeight");

                entity.Property(e => e.NetWeight)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("netWeight");

                entity.Property(e => e.Packaging)
                    .HasMaxLength(255)
                    .HasColumnName("packaging");

                entity.Property(e => e.Terms)
                    .HasMaxLength(255)
                    .HasColumnName("terms");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InteranlId)
                    .HasName("PK__Invoice__1B0114ED61A5BE0B");

                entity.ToTable("Invoice", "taxes");

                entity.HasIndex(e => e.DeliveryId, "IX_Invoice_deliveryId");

                entity.HasIndex(e => e.IssuerId, "IX_Invoice_issuerId");

                entity.HasIndex(e => e.PaymentId, "IX_Invoice_paymentId");

                entity.HasIndex(e => e.ReceiverId, "IX_Invoice_receiverId");

                entity.Property(e => e.InteranlId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("interanlId");

                entity.Property(e => e.DateIssued)
                    .HasColumnType("date")
                    .HasColumnName("dateIssued");

                entity.Property(e => e.DeliveryId).HasColumnName("deliveryId");

                entity.Property(e => e.DocumentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documentType");

                entity.Property(e => e.DocumentTypeversion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documentTypeversion");

                entity.Property(e => e.ExtraDiscountAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("extraDiscountAmount");

                entity.Property(e => e.IssuerId).HasColumnName("issuerId");

                entity.Property(e => e.NetAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("netAmount");

                entity.Property(e => e.PaymentId).HasColumnName("paymentId");

                entity.Property(e => e.ProformaInvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("proformaInvoiceNumber");

                entity.Property(e => e.PurchaseOrderDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("purchaseOrderDescription");

                entity.Property(e => e.PurchaseOrderReference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("purchaseOrderReference");

                entity.Property(e => e.ReceiverId).HasColumnName("receiverId");

                entity.Property(e => e.SalesOrderDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("salesOrderDescription");

                entity.Property(e => e.SalesOrderReference)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("salesOrderReference");

                entity.Property(e => e.TaxpayerActivityCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("taxpayerActivityCode");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalAmount");

                entity.Property(e => e.TotalDiscountAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalDiscountAmount");

                entity.Property(e => e.TotalItemsDiscountAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalItemsDiscountAmount");

                entity.Property(e => e.TotalSalesAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalSalesAmount");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Invoice__deliver__32E0915F");

                entity.HasOne(d => d.Issuer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IssuerId)
                    .HasConstraintName("FK__Invoice__issuerI__300424B4");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Invoice__payment__31EC6D26");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ReceiverId)
                    .HasConstraintName("FK__Invoice__receive__30F848ED");
            });

            modelBuilder.Entity<Issuer>(entity =>
            {
                entity.ToTable("Issuer", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalInformation)
                    .HasMaxLength(255)
                    .HasColumnName("additionalInformation");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(255)
                    .HasColumnName("branchId");

                entity.Property(e => e.BuildingNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("buildingNumber");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.FlatNumber)
                    .HasMaxLength(255)
                    .HasColumnName("flatNumber");

                entity.Property(e => e.Floor)
                    .HasMaxLength(255)
                    .HasColumnName("floor");

                entity.Property(e => e.Governate)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("governate");

                entity.Property(e => e.Landmark)
                    .HasMaxLength(255)
                    .HasColumnName("landmark");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("postalCode");

                entity.Property(e => e.PriceThreshold)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("priceThreshold");

                entity.Property(e => e.RegionCity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("regionCity");

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("registrationNumber");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payments", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BankAccountIban)
                    .HasMaxLength(255)
                    .HasColumnName("bankAccountIBAN");

                entity.Property(e => e.BankAccountNo)
                    .HasMaxLength(255)
                    .HasColumnName("bankAccountNo");

                entity.Property(e => e.BankAddress)
                    .HasMaxLength(255)
                    .HasColumnName("bankAddress");

                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .HasColumnName("bankName");

                entity.Property(e => e.SwiftCode)
                    .HasMaxLength(255)
                    .HasColumnName("swiftCode");

                entity.Property(e => e.Terms)
                    .HasMaxLength(255)
                    .HasColumnName("terms");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "business");

                entity.HasIndex(e => e.InvoiceInternalId, "IX_Products_invoiceInternalId");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.AmountEgp)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("amountEGP");

                entity.Property(e => e.AmountSold)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("amountSold");

                entity.Property(e => e.CurrencyExchangeRate)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("currencyExchangeRate");

                entity.Property(e => e.CurrencySold)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("currencySold");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("discountAmount");

                entity.Property(e => e.DiscountRate)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("discountRate");

                entity.Property(e => e.InternalCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("internalCode");

                entity.Property(e => e.InvoiceInternalId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("invoiceInternalId");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("itemCode");

                entity.Property(e => e.ItemType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("itemType");

                entity.Property(e => e.ItemsDiscount)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("itemsDiscount");

                entity.Property(e => e.NetTotal)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("netTotal");

                entity.Property(e => e.Quantity)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("quantity");

                entity.Property(e => e.SalesTotal)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("salesTotal");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("total");

                entity.Property(e => e.TotalTaxableFees)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("totalTaxableFees");

                entity.Property(e => e.UnitType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("unitType");

                entity.Property(e => e.ValueDifference)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("valueDifference");

                entity.HasOne(d => d.InvoiceInternal)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.InvoiceInternalId)
                    .HasConstraintName("FK__Products__invoic__38996AB5");
            });

            modelBuilder.Entity<Receiver>(entity =>
            {
                entity.ToTable("Receiver", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalInformation)
                    .HasMaxLength(255)
                    .HasColumnName("additionalInformation");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(255)
                    .HasColumnName("branchId");

                entity.Property(e => e.BuildingNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("buildingNumber");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .HasColumnName("country");

                entity.Property(e => e.FlatNumber)
                    .HasMaxLength(255)
                    .HasColumnName("flatNumber");

                entity.Property(e => e.Floor)
                    .HasMaxLength(255)
                    .HasColumnName("floor");

                entity.Property(e => e.Governate)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("governate");

                entity.Property(e => e.Landmark)
                    .HasMaxLength(255)
                    .HasColumnName("landmark");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .HasColumnName("postalCode");

                entity.Property(e => e.RegionCity)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("regionCity");

                entity.Property(e => e.RegistrationNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("registrationNumber");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Signature>(entity =>
            {
                entity.ToTable("Signatures", "business");

                entity.HasIndex(e => e.InvoiceInternalId, "IX_Signatures_invoiceInternalId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InvoiceInternalId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("invoiceInternalId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.InvoiceInternal)
                    .WithMany(p => p.Signatures)
                    .HasForeignKey(d => d.InvoiceInternalId)
                    .HasConstraintName("FK__Signature__invoi__3B75D760");
            });

            modelBuilder.Entity<SubmittedDoc>(entity =>
            {
                entity.ToTable("SubmittedDocs", "business");

                entity.HasIndex(e => e.InvoiceInternalId, "IX_SubmittedDocs_invoiceInternalId");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .HasColumnName("id");

                entity.Property(e => e.InvoiceInternalId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("invoiceInternalId");

                entity.Property(e => e.LongId)
                    .HasMaxLength(255)
                    .HasColumnName("longId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.InvoiceInternal)
                    .WithMany(p => p.SubmittedDocs)
                    .HasForeignKey(d => d.InvoiceInternalId)
                    .HasConstraintName("FK__Submitted__invoi__35BCFE0A");
            });

            modelBuilder.Entity<TaxType>(entity =>
            {
                entity.ToTable("TaxTypes", "taxes");

                entity.HasIndex(e => e.InvoiceInternalId, "IX_TaxTypes_invoiceInternalId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 5)")
                    .HasColumnName("amount");

                entity.Property(e => e.InvoiceInternalId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("invoiceInternalId");

                entity.Property(e => e.Rate)
                    .HasColumnType("decimal(20, 5)")
                    .HasColumnName("rate");

                entity.Property(e => e.SubType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("subType");

                entity.Property(e => e.TaxType1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("taxType");

                entity.HasOne(d => d.InvoiceInternal)
                    .WithMany(p => p.TaxTypes)
                    .HasForeignKey(d => d.InvoiceInternalId)
                    .HasConstraintName("FK__TaxTypes__invoic__3E52440B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "business");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Usersdetail>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Usersdet__CBA1B25706F63767");

                entity.ToTable("Usersdetails", "business");

                entity.Property(e => e.Userid)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.FullAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fullAddress");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fullName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("street");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Usersdetail)
                    .HasForeignKey<Usersdetail>(d => d.Userid)
                    .HasConstraintName("FK__Usersdeta__fullA__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
