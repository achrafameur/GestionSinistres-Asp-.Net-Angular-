import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';
import interactionPlugin from '@fullcalendar/interaction';
import listPlugin from '@fullcalendar/list';
import timeGridPlugin from '@fullcalendar/timegrid';
import { TranslateModule } from '@ngx-translate/core';
import { HomeComponent } from './home/home.component';



// routing
const routes: Routes = [
  {
    path: 'product',
    loadChildren: () => import('./production/product/product.module').then(m => m.ProductModule)
  } ,
  {
    path: 'email',
    loadChildren: () => import('./email/email.module').then(m => m.EmailModule)
  },
  {
    path: 'chat',
    loadChildren: () => import('./chat/chat.module').then(m => m.ChatModule)
  },
  // {
  //   path: 'quotation',
  //   loadChildren: () => import('./quotation/quotation.module').then(m => m.QuotationModule)
  // },
  {
    path: 'todo',
    loadChildren: () => import('./todo/todo.module').then(m => m.TodoModule)
  },
  {
    path: 'calendar',
    loadChildren: () => import('./calendar/calendar.module').then(m => m.CalendarModule)
  },
  {
    path: 'invoice',
    loadChildren: () => import('./invoice/invoice.module').then(m => m.InvoiceModule)
  },
  {
    path: 'e-commerce',
    loadChildren: () => import('./ecommerce/ecommerce.module').then(m => m.EcommerceModule)
  },
  {
    path: 'user',
    loadChildren: () => import('./user/user.module').then(m => m.UserModule)
  },
  {
    path: 'branch',
    loadChildren: () => import('./branch/branch.module').then(m => m.BranchModule)
  },
  {
    path: 'warranty',
    loadChildren: () => import('./warranty/warranty.module').then(m => m.WarrantyModule)
  },
  {
    path: 'feature',
    loadChildren: () => import('./feature/feature.module').then(m => m.FeatureModule)
  },
  {
    path: 'sinisterNature',
    loadChildren: () => import('./sinister-nature/sinister-nature.module').then(m => m.SinisterNatureModule)
  },
  {
    path: 'status',
    loadChildren: () => import('./status/status.module').then(m => m.StatusModule)
  },
  {
    path: 'expert',
    loadChildren: () => import('./expert/expert.module').then(m => m.ExpertModule)
  },
  {
    path: 'average-cost',
    loadChildren: () => import('./average-cost/average-cost.module').then(m => m.AverageCostModule)
  },
  {
    path: 'third-party',
    loadChildren: () => import('./third-party/third-party.module').then(m => m.ThirdPartyModule)
  },
  {
    path: 'third-company',
    loadChildren: () => import('./third-company/third-company.module').then(m => m.ThirdCompanyModule)
  },
  {
    path: 'Sinister-Declaration',
    loadChildren: () => import('./sinister-declaration/sinister-declaration.module').then(m => m.SinisterDeclarationModule)
  },
  {
    path: 'SinisterBinders',
    loadChildren: () => import('./sinister-list/sinister-list.module').then(m => m.SinisterListModule)
  },
  {
    path: 'duration',
    loadChildren: () => import('./duration/duartion.module').then(m => m.DuartionModule)
  } ,
  {
    path: 'fees',
    loadChildren: () => import('./fees/fees.module').then(m => m.FeesModule)
  } ,
  {
    path: 'tax',
    loadChildren: () => import('./tax/tax.module').then(m => m.TaxModule)
  } ,
  {
    path: 'chain-element',
    loadChildren: () => import('../pages/chain-element/chain-element.module').then(m => m.ChainElementModule)
  } ,
  {
    path: 'proportion',
    loadChildren: () => import('../pages/proportion/proportion.module').then(m => m.ProportionModule)
  } ,
  {
    path: 'chain',
    loadChildren: () => import('../pages/chain/chain.module').then(m => m.ChainModule)
  } ,
  {
    path: 'nature',
    loadChildren: () => import('../pages/nature/nature.module').then(m => m.NatureModule)
  } ,
  {
    path: 'article',
    loadChildren: () => import('../pages/article/article.module').then(m => m.ArticleModule)
  },
  {
    path: 'commission',
    loadChildren: () => import('../apps/commission/commission.module').then(m => m.CommissionModule)
  },
  {
    path: 'pages',
    loadChildren: () => import('../apps/home/home.module').then(m => m.HomeModule)
  }
];

FullCalendarModule.registerPlugins([dayGridPlugin, timeGridPlugin, listPlugin, interactionPlugin]);

@NgModule({
  declarations: [
  ],
  imports: [CommonModule, RouterModule.forChild(routes), TranslateModule]
})
export class AppsModule {}
