import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommissionUpdateComponent } from './commission-update.component';

describe('CommissionUpdateComponent', () => {
  let component: CommissionUpdateComponent;
  let fixture: ComponentFixture<CommissionUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommissionUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CommissionUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
