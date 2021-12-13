package qc.worker.data;

public class LoadedRecord {

    private String record1, record2, record3, record4, record5, record6;
    private boolean isSelected = false;

    public String getRecord1(){
        return record1;
    }
    public void setRecord1(String record){
        this.record1 = record;
    }

    public String getRecord2(){
        return record2;
    }
    public void setRecord2(String record){
        this.record2 = record;
    }

    public String getRecord3(){
        return record3;
    }
    public void setRecord3(String record){
        this.record3 = record;
    }

    public String getRecord4(){
        return record4;
    }
    public void setRecord4(String record){ this.record4 = record; }

    public String getRecord5(){
        return record5;
    }
    public void setRecord5(String record){
        this.record5 = record;
    }

    public String getRecord6(){
        return record6;
    }
    public void setRecord6(String record){ this.record6 = record; }

    public void setSelected(boolean selected) { this.isSelected = selected;    }
    public boolean isSelected() { return this.isSelected;    }


}