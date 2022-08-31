import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CardModule } from 'app/main/ui/card/card.module';
import { ColorsModule } from 'app/main/ui/colors/colors.module';
import { IconsModule } from 'app/main/ui/icons/icons.module';
import { PageLayoutsModule } from 'app/main/ui/page-layouts/page-layouts.module';
import { TypographyModule } from 'app/main/ui/typography/typography.module';

const routes: Routes = [
  
];

@NgModule({
  imports: [
    ColorsModule,
    IconsModule,
    CardModule, 
    TypographyModule, 
    PageLayoutsModule,
    CommonModule, 
    RouterModule.forChild(routes)
  ],
  declarations: [
  ]
})
export class UIModule {}
