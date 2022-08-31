import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ArticleService } from 'app/main/pages/article/article.service';
import { FeatureDto } from 'app/main/pages/interfaces/feature';
import { Item } from 'app/main/pages/interfaces/item';
import { Nature } from 'app/main/pages/interfaces/nature';
import { NatureService } from 'app/main/pages/nature/nature.service';
import { FeatureService } from '../feature.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';

@Component({
  selector: 'app-feature-detail',
  templateUrl: './feature-detail.component.html',
  styleUrls: ['./feature-detail.component.scss'],
})
export class FeatureDetailComponent implements OnInit {
  feature: FeatureDto;
  nature: Nature;
  public contentHeader: object;
  public itemList: Item[];
  public FeatureItemId: any;
  public itemIds: any;
  public featureItems: any[] = [];
  public id: number;

  constructor(
    private itemService: ArticleService,
    private router: Router,
    private featureService: FeatureService,
    private natureService: NatureService,
    private activatedroute: ActivatedRoute,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(English, Francais);
  }

  ngOnInit(): void {
    this.id = this.activatedroute.snapshot.params.id;

    this.featureService.loadFeatureById(this.id).subscribe((data) => {
      this.featureService.getItemsByFeatureId(this.id).subscribe((data) => {
        this.feature.featureItems = data;
        console.log(this.feature.featureItems);
      });

      this.feature = data;
      console.log(data);
    });

    this.contentHeader = {
      headerTitle: ' Feature',
      actionButton: false,
      breadcrumb: {
        type: '',
        links: [
          {
            name: 'Home',
            isLink: true,
            link: '/',
          },
          {
            name: 'Feature',
            isLink: true,
            link: '/apps/feature/list',
          },
          {
            name: 'Detail',
            isLink: false,
          },
        ],
      },
    };
  }
  // attachFeatureItems(featureItemsForm: NgForm) {
  //   this.FeatureItemId = this.itemList
  //     .filter((x) => x.isChecked == true)
  //     .map((x) => x.id)
  //     .toString();
  //   console.log(this.FeatureItemId);
  //   this.itemIds = this.FeatureItemId.split(',');
  //   for (let i = 0; i < this.itemIds.length; i++) {
  //     console.log(featureItemsForm.value)
  //     if (featureItemsForm.value.featureItemId == true) {
  //       this.featureItems.push({
  //         itemId: this.itemIds[i],
  //       });
  //       console.log(this.featureItems);
  //       console.log(this.itemIds);
  //     }
  //   }
  //   this.featureService.setFeatureItems(this.id, this.featureItems).subscribe({
  //     next: () => {
  //       this.router.navigate(['/apps/feature/list']);
  //     },
  //     error: (error) => {
  //       console.log(error);
  //     },
  //   });
  // }
  // onChange() {
  //   console.log(this.itemList);
  // }
}
