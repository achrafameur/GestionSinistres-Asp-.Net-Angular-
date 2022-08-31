import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WarrantyUpdateComponent } from './warranty-update.component';

describe('WarrantyUpdateComponent', () => {
  let component: WarrantyUpdateComponent;
  let fixture: ComponentFixture<WarrantyUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WarrantyUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WarrantyUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
